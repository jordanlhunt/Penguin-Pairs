using Project1.Engine;
using Project1.Engine.UserInterface;
using Vector2 = Microsoft.Xna.Framework.Vector2;

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
            quitButton.LocalPosition = new Vector2(1058, 20);
            gameObjectsList.AddChild(quitButton);
            hintButton = new Button("Sprites/UI/spr_button_hint");
            hintButton.LocalPosition = new Vector2(916, 20);
            gameObjectsList.AddChild(hintButton);
            retryButton = new Button("Sprites/UI/spr_button_retry");
            retryButton.LocalPosition = new Vector2(916, 20);
            retryButton.IsVisible = false;
            gameObjectsList.AddChild(retryButton);
        }
        #endregion
        #region Public Methods
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (retryButton.IsPressed)
            {
                // TODO: Add Logic for Retry
            }
            if (hintButton.IsPressed)
            {
                // TODO: Add Logic for Hint
            }
            if (quitButton.IsPressed)
            {
                ExtendedGame.GameStateManager.SwitchGameState(PenguinPairs.STATENAME_LEVELSELECT);
            }
        }
        #endregion
        #region Private Methods
        #endregion
    }
}
