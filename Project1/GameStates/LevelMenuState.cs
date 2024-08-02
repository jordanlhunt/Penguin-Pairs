using Project1.Engine;

namespace Project1.GameStates
{
    internal class LevelMenuState : GameState
    {
        #region Member Variables
        #endregion
        #region Properties
        #endregion
        #region Constructor
        public LevelMenuState()
        {
            SpriteGameObject levelMenuStateSprite = new SpriteGameObject("Sprites/spr_background_level");
            // gameObjectsList is a protected variable, so subclasses of GameState can access it. 
            gameObjectsList.AddChild(levelMenuStateSprite);
        }
        #endregion
        #region Public Methods
        #endregion
        #region Private Methods
        #endregion
    }
}
