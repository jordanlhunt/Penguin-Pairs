using Project1.Engine;

namespace Project1.GameStates
{
    internal class TitleMenuState : GameState
    {
        #region Member Variables
        #endregion
        #region Properties
        #endregion
        #region Constructor
        public TitleMenuState()
        {
            SpriteGameObject titleScreenSprite = new SpriteGameObject("Sprites/spr_titlescreen");
            // gameObjectsList is a protected variable, so subclasses of GameState can access it. 
            gameObjectsList.AddChild(titleScreenSprite);
        }
        #endregion
        #region Public Methods
        #endregion
        #region Private Methods
        #endregion
    }
}
