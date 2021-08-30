using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Devcade_Library.DevcadeControls
{
    /// <summary>
    /// The buttons on each player's controller
    /// </summary>
    enum ControllerButtons
    {
        a1,
        a2,
        a3,
        a4,
        b1,
        b2,
        b3,
        b4,
        menu1,
        menu2
    }

    /// <summary>
    /// What direction the joystick is pulled in
    /// </summary>
    enum JoystickDirection
    {
        Right,
        Up,
        Left,
        Down,
        UpLeft,
        UpRight,
        DownLeft,
        DownRight,
        Neutral
    }

    /// <summary>
    /// A container for the joystick and buttons that make up a player's controls
    /// </summary>
    class Controller
    {
        public Joystick joystick;
        public Dictionary<ControllerButtons, Button> buttons;

        private PlayerIndex playerID;

        /// <summary>
        /// Initializes a controller for a given player
        /// </summary>
        /// <param name="playerID">The controller to initialize (players One or Two)</param>
        public Controller(PlayerIndex playerID)
        {
            this.playerID = playerID;
            joystick = new Joystick();
            buttons = new Dictionary<ControllerButtons, Button>()
            {
                {
                    ControllerButtons.a1,
                    new Button(Buttons.X)
                },
                {
                    ControllerButtons.a2,
                    new Button(Buttons.Y)
                },
                {
                    ControllerButtons.a3,
                    new Button(Buttons.RightShoulder)
                },
                {
                    ControllerButtons.a4,
                    new Button(Buttons.LeftShoulder)
                },
                {
                    ControllerButtons.b1,
                    new Button(Buttons.A)
                },
                {
                    ControllerButtons.b2,
                    new Button(Buttons.B)
                },
                {
                    ControllerButtons.b3,
                    new Button(Buttons.RightTrigger)
                },
                {
                    ControllerButtons.b4,
                    new Button(Buttons.LeftTrigger)
                }
            };
        }

        /// <summary>
        /// Updates the states of all inputs for this controller
        /// </summary>
        public void Update()
        {
            GamePadState controllerState = GamePad.GetState(playerID);
            joystick.Update(controllerState);
            foreach (Button button in buttons.Values)
            {
                button.Update(GamePad.GetState(playerID));
            }
        }
    }
}
