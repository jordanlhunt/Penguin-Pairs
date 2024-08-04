using Project1.Engine;
using System.Diagnostics;
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
            if (inputHelper.IsKeyPressed(Keys.H))
            {
                ExtendedGame.GameStateManager.SwitchGameState(PenguinPairs.STATENAME_HELP);
                Debug.WriteLine("[TitleMenuState.cs] - HandleInput() - Switch to Help Screen");
            }
        }
        #endregion
        #region Private Methods
        #endregion
    }
}
