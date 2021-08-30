using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Devcade_Library.DevcadeControls
{
    /// <summary>
    /// Wrapper for the joystick that translates from xbox to cabinet and adds helper functions
    /// </summary>
    class Joystick
    {
        private Vector2 currentPos;
        private Vector2 previousPos;

        public Joystick()
        {
            previousPos = Vector2.Zero;
        }

        /// <summary>
        /// Updates the class data with the current frame's joystick state
        /// </summary>
        /// <param name="controllerState">The current state of the controller</param>
        public void Update(GamePadState controllerState)
        {
            previousPos = currentPos;
            currentPos = controllerState.ThumbSticks.Left;
        }

        /// <summary>
        /// The position of the joystick
        /// </summary>
        /// <returns>X and Y of the joystick head, locked between -1 and 1</returns>
        public Vector2 GetPos()
        {
            return currentPos;
        }

        /// <summary>
        /// How much the joystick moved this frame
        /// </summary>
        /// <returns>X and Y delta for this frame</returns>
        public Vector2 GetDelta()
        {
            return currentPos - previousPos;
        }

        /// <summary>
        /// The angle of the joystick projected onto the base
        /// </summary>
        /// <returns>Angle in degrees of the joystick</returns>
        public float GetAngle()
        {
            return FindDegree(currentPos.X, currentPos.Y);
        }

        /// <summary>
        /// How much the joystick rotated this frame
        /// </summary>
        /// <returns>Angle delta for this frame in degrees</returns>
        public float GetAngleDelta()
        {
            return GetAngle() - FindDegree(previousPos.X, previousPos.Y);
        }

        /// <summary>
        /// How far the stick is pulled
        /// </summary>
        /// <returns>The distance, locked between -1 and 1. 
        /// The distance may be uneven at max give due to physical offsets</returns>
        public float GetMagnitude()
        {
            return currentPos.Length();
        }

        /// <summary>
        /// How far the joystick was moved away from the center this frame
        /// </summary>
        /// <returns>Distance between -2 and 2</returns>
        public float GetMagnitudeDelta()
        {
            return GetMagnitude() - previousPos.Length();
        }

        /// <summary>
        /// Finds what quadrant the joystick is currently pointing it
        /// </summary>
        /// <returns>The JoystickDirection representing it's current direction, Neutral if centered</returns>
        public JoystickDirection GetQuadrant()
        {
            float angle = GetAngle();

            if (currentPos.X == 0 && currentPos.Y == 0) return JoystickDirection.Neutral;

            if (angle > 45 && angle <= 135)
            {
                return JoystickDirection.Down;
            }
            else if (angle > 135 && angle <= 225)
            {
                return JoystickDirection.Left;
            }
            else if (angle > 225 && angle <= 315)
            {
                return JoystickDirection.Up;
            }
            return JoystickDirection.Right;
        }

        /// <summary>
        /// Finds what octant the joystick is currently pointing it
        /// </summary>
        /// <returns>The JoystickDirection representing it's current direction, Neutral if centered</returns>
        public JoystickDirection GetOctant()
        {
            float angle = GetAngle();

            if (currentPos.X == 0 && currentPos.Y == 0) return JoystickDirection.Neutral;

            if (angle > 22.5 && angle <= 67.5)
            {
                return JoystickDirection.DownRight;
            }
            else if (angle > 67.5 && angle <= 112.5)
            {
                return JoystickDirection.Down;
            }
            else if (angle > 112.5 && angle <= 157.5)
            {
                return JoystickDirection.DownLeft;
            }
            else if (angle > 157.5 && angle <= 202.5)
            {
                return JoystickDirection.Left;
            }
            else if (angle > 202.5 && angle <= 247.5)
            {
                return JoystickDirection.UpLeft;
            }
            else if (angle > 247.5 && angle <= 292.5)
            {
                return JoystickDirection.Up;
            }
            else if (angle > 292.5 && angle <= 337.5)
            {
                return JoystickDirection.UpRight;
            }
            return JoystickDirection.Right;
        }

        /// <summary>
        /// Returns the angle the joystick is currently in.
        /// Special thanks to: https://answers.unity.com/questions/1032673/how-to-get-0-360-degree-from-two-points.html
        /// </summary>
        /// <param name="x">X position of the joystick</param>
        /// <param name="y">Y position of the joystick</param>
        /// <param name="centered">Whether the joystick is centered</param>
        /// <returns>The angle in degrees, with right as 0 and increasing clockwise.</returns>
        private static float FindDegree(float x, float y)
        {
            float value = (float)(Math.Atan2(x, y) / Math.PI * 180f) - 90;
            if (value < 0) value += 360f;
            return value;
        }
    }
}
