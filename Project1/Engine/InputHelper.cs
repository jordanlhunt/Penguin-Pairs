﻿using Microsoft.Xna.Framework.Input;
using System.Numerics;

namespace Project1.Engine
{
    internal class InputHelper
    {
        #region Member Variables
        MouseState currentMouseState;
        MouseState previousMouseState;
        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;
        #endregion
        #region Properties
        /// <summary>
        /// Get the current position of the Mouse, relative to the top-left corner of the screen
        /// </summary>
        public Vector2 MousePosition
        {
            get
            {
                return new Vector2(currentMouseState.X, currentMouseState.Y);
            }
        }
        #endregion
        #region Constructor
        #endregion
        #region Public Methods
        /// <summary>
        /// Updates the InputHelper object from one frame of the game loop. Retrieves the current state of the mouse and keyboard, and the stores the previous state
        /// </summary>
        public void Update()
        {
            previousKeyboardState = currentKeyboardState;
            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
            currentKeyboardState = Keyboard.GetState();
        }
        /// <summary>
        /// Checks if the player has started pressing the left mouse button in the last frame of the game loop
        /// </summary>
        /// <returns>true if the left mouse is now being pressed and was not yet pressed in the previous frame; else false</returns>
        public bool IsMouseLeftButtonPressed()
        {
            return ((currentMouseState.LeftButton == ButtonState.Pressed) && (previousMouseState.LeftButton == ButtonState.Released));
        }
        public bool IsKeyPressed(Keys someKey)
        {
            return (currentKeyboardState.IsKeyDown(someKey) && previousKeyboardState.IsKeyUp(someKey));
        }
        #endregion
        #region Private Methods
        #endregion
    }
}
