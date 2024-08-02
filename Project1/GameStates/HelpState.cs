using Project1.Engine;

namespace Project1.GameStates
{
    internal class HelpState : GameState
    {
        #region Member Variables
        #endregion
        #region Properties
        #endregion
        #region Constructor
        public HelpState()
        {
            SpriteGameObject helpStateSprite = new SpriteGameObject("Sprites/spr_background_help");
            // gameObjectsList is a protected variable, so subclasses of GameState can access it. 
            gameObjectsList.AddChild(helpStateSprite);
        }
        #endregion
        #region Public Methods
        #endregion
        #region Private Methods
        #endregion
    }
}
