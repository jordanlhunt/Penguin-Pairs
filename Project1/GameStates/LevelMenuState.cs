using Microsoft.Xna.Framework.Input;
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
            SpriteGameObject levelMenuStateSprite = new SpriteGameObject("Sprites/spr_background_levelselect");
            // gameObjectsList is a protected variable, so subclasses of GameState can access it. 
            gameObjectsList.AddChild(levelMenuStateSprite);
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
