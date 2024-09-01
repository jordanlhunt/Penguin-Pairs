using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Project1.Engine
{
    /// <summary>
    /// A non-visual game object has a list of game objects as its children
    /// </summary>
    internal class GameObjectList : GameObject
    {
        #region Member Variables
        /// <summary>
        /// The child objects of this game objects
        /// </summary>
        List<GameObject> children;
        #endregion
        #region Properties
        #endregion
        #region Constructor
        /// <summary>
        /// Creates a new GameObjectList with an empty list of children
        /// </summary>
        public GameObjectList()
        {
            children = new List<GameObject>();
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Adds an object to this GameObjectList, and sets this GameObjectList as the parent of that object.
        /// </summary>
        /// <param name="child">The game object to add</param>
        public void AddChild(GameObject child)
        {
            child.Parent = this;
            children.Add(child);
        }

        /// <summary>
        /// Peforms input handling for all the game objects in the list of children
        /// </summary>
        /// <param name="inputHelper">An object required for handling player input</param>
        public override void HandleInput(InputHelper inputHelper)
        {
            for (int i = children.Count - 1; i >= 0; i--)
            {
                children[i].HandleInput(inputHelper);
            }
        }
        /// <summary>
        /// Pefroms the Update for all the game objects in the list of children
        /// </summary>
        /// <param name="gameTime">An object containing information about how much time has passed</param>
        public override void Update(GameTime gameTime)
        {
            foreach (GameObject child in children)
            {
                child.Update(gameTime);
            }
        }
        /// <summary>
        /// Peforms the Draw for all the game objects in the list of children
        /// </summary>
        /// <param name="gameTime">An object containing information about how much time has passed</param>
        /// <param name="spriteBatch">A sprite batch object used for drawing sprites</param>
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (IsVisible == false)
            {
                return;
            }

            foreach (GameObject child in children)
            {
                child.Draw(gameTime, spriteBatch);
            }
        }
        /// <summary>
        /// Peforms the Reset for all the game objects in the list of children
        /// </summary>
        public override void Reset()
        {
            foreach (GameObject child in children)
            {
                child.Reset();
            }
        }

        #endregion
        #region Private Methods
        #endregion
    }
}
