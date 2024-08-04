using Microsoft.Xna.Framework.Input;
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
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.IsKeyPressed(Keys.Back))
            {
                ExtendedGame.GameStateManager.SwitchGameState(PenguinPairs.STATENAME_TITLE);
            }
        }
        #endregion
        #region Private Methods
        #endregion
    }
}
