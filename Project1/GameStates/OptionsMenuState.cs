using Project1.Engine;

namespace Project1.GameStates
{
    internal class OptionsMenuState : GameState
    {
        #region Member Variables
        #endregion
        #region Properties
        #endregion
        #region Constructor
        public OptionsMenuState()
        {
            SpriteGameObject optionMenuStateSprite = new SpriteGameObject("Sprites/spr_background_options");
            // gameObjectsList is a protected variable, so subclasses of GameState can access it. 
            gameObjectsList.AddChild(optionMenuStateSprite);
        }
        #endregion
        #region Public Methods
        #endregion
        #region Private Methods
        #endregion
    }
}
