using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1.Engine
{
    internal abstract class GameState : IGameLoopObject
    {
        #region Member Variables
        protected GameObjectList gameObjectsList;
        #endregion
        #region Properties
        #endregion
        #region Constructor
        protected GameState()
        {
            gameObjectsList = new GameObjectList();
        }
        #endregion
        #region Public Methods
        public virtual void HandleInput(InputHelper inputHelper)
        {
            gameObjectsList.HandleInput(inputHelper);
        }
        public virtual void Update(GameTime gameTime)
        {
            gameObjectsList.Update(gameTime);
        }
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            gameObjectsList.Draw(gameTime, spriteBatch);
        }
        public virtual void Reset()
        {
            gameObjectsList.Reset();
        }
        #endregion
        #region Private Methods
        #endregion
    }
}
