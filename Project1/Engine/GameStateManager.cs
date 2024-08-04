using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Project1.Engine
{
    internal class GameStateManager
    {
        #region Member Variables
        /// <summary>
        /// A dictionary data structure 
        /// </summary>
        Dictionary<string, GameState> gameStatesDictionary;
        GameState currentGameState;
        #endregion
        #region Properties
        #endregion
        #region Constructor
        /// <summary>
        /// Creates an new instance of the GameStateManager
        /// </summary>
        public GameStateManager()
        {
            gameStatesDictionary = new Dictionary<string, GameState>();
            currentGameState = null;
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Adds a GameState object into the dictionary
        /// </summary>
        /// <param name="gameStateName">The string name of the gameState</param>
        /// <param name="gameState">The actual gameState object to add</param>
        public void AddGameState(string gameStateName, GameState gameState)
        {
            gameStatesDictionary[gameStateName] = gameState;
        }
        /// <summary>
        /// Retrieves the game state passed in. 
        /// </summary>
        /// <param name="gameStateName">the string key to search the dictionary to find the gameState</param>
        /// <returns>A gameState object</returns>
        public GameState GetGameState(string gameStateName)
        {
            if (gameStatesDictionary.ContainsKey(gameStateName))
            {
                return gameStatesDictionary[gameStateName];
            }
            else
            {
                Console.WriteLine("[GAMESTATEMANAGER.CS] - GetGameState() - null gameState returned");
                return null;
            }
        }
        /// <summary>
        /// This method changes the currentGameState to some target gameState
        /// </summary>
        /// <param name="gameStateName"></param>
        public void SwitchGameState(string gameStateName)
        {
            if (gameStatesDictionary.ContainsKey(gameStateName))
            {
                currentGameState = gameStatesDictionary[gameStateName];
            }
            else
            {
                Debug.WriteLine("[GameStateManager.cs] - SwitchGameState() - gameStateName not found");
            }
        }
        /// <summary>
        /// Calls the update function for the current GameState
        /// </summary>
        /// <param name="gameTime">an object that has time information</param>
        public void Update(GameTime gameTime)
        {
            if (currentGameState != null)
            {
                currentGameState.Update(gameTime);
            }
        }
        /// <summary>
        /// Handles the input for the current gameState
        /// </summary>
        /// <param name="inputHelper">a reference to the InputHelper</param>
        public void HandleInput(InputHelper inputHelper)
        {
            if (currentGameState != null)
            {
                currentGameState.HandleInput(inputHelper);
            }

        }
        /// <summary>
        /// Calls the draw method for the current gameState
        /// </summary>
        /// <param name="gameTime">n object that has time information</param>
        /// <param name="spriteBatch">The Monogame spriteBatch for drawing</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (currentGameState != null)
            {
                currentGameState.Draw(gameTime, spriteBatch);
            }
        }
        /// <summary>
        /// Calls the reset method of the currentGameState
        /// </summary>
        public void Reset()
        {
            if (currentGameState != null)
            {
                currentGameState.Reset();
            }
        }
        #endregion
        #region Private Methods
        #endregion
    }
}
