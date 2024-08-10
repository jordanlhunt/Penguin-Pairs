using Microsoft.Xna.Framework.Input;
using Project1.Engine;
using Project1.Engine.UserInterface;

namespace Project1.GameStates
{
    internal class PlayingState : GameState
    {
        #region Member Variables
        Button hintButton;
        Button retryButton;
        Button quitButton;
        #endregion
        #region Properties
        #endregion
        #region Constructor
        public PlayingState()
        {
            SpriteGameObject playingStateSprite = new SpriteGameObject("Sprites/spr_background_level");
            // gameObjectsList is a protected variable, so subclasses of GameState can access it. 
            gameObjectsList.AddChild(playingStateSprite);
            quitButton = new Button("Sprites/UI/spr_button_quit");
        }
        #endregion
        #region Public Methods
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.IsKeyPressed(Keys.Back))
            {
                ExtendedGame.GameStateManager.SwitchGameState(PenguinPairs.STATENAME_LEVELSELECT);
            }
        }
        #endregion
        #region Private Methods
        #endregion
    }
}
