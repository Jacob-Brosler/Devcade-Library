using Microsoft.Xna.Framework.Input;

namespace Devcade_Library.DevcadeControls
{
    /// <summary>
    /// Wrapper for the buttons that translates from xbox to cabinet and adds helper functions
    /// </summary>
    class Button
    {
        private Buttons buttonID;
        private bool currentState;
        private bool previousState;

        public Button(Buttons buttonID)
        {
            this.buttonID = buttonID;
            previousState = false;
        }

        /// <summary>
        /// Updates the class data with the current frame's button state
        /// </summary>
        /// <param name="controllerState">The current state of the controller</param>
        public void Update(GamePadState controllerState)
        {
            previousState = currentState;
            currentState = controllerState.IsButtonDown(buttonID);
        }

        /// <summary>
        /// Is the button pressed
        /// </summary>
        public bool IsDown()
        {
            return currentState;
        }

        /// <summary>
        /// Was the button pressed this frame
        /// </summary>
        public bool WasPressed()
        {
            return currentState && !previousState;
        }

        /// <summary>
        /// Was the button released this frame
        /// </summary>
        public bool WasReleased()
        {
            return previousState && !currentState;
        }
    }
}
