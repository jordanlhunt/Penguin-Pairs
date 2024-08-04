using Project1.Engine;
using Keys = Microsoft.Xna.Framework.Input.Keys;
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
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            // Go to Help
            if (inputHelper.IsKeyPressed(Keys.H))
            {
                ExtendedGame.GameStateManager.SwitchGameState(PenguinPairs.STATENAME_HELP);
            }
            // Go to options
            if (inputHelper.IsKeyPressed(Keys.O))
            {
                ExtendedGame.GameStateManager.SwitchGameState(PenguinPairs.STATENAME_OPTIONS);
            }
            // Go to Level Select
            if (inputHelper.IsKeyPressed(Keys.L))
            {
                ExtendedGame.GameStateManager.SwitchGameState(PenguinPairs.STATENAME_LEVELSELECT);
            }
        }
        #endregion
        #region Private Methods
        #endregion
    }
}
