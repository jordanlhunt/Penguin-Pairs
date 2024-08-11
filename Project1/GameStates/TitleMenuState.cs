using Project1.Engine;
using Project1.Engine.UserInterface;
using Vector2 = Microsoft.Xna.Framework.Vector2;
namespace Project1.GameStates
{
    internal class TitleMenuState : GameState
    {
        #region Member Variables
        Button playButton;
        Button optionsButton;
        Button helpButton;
        #endregion
        #region Properties
        #endregion
        #region Constructor
        public TitleMenuState()
        {
            SpriteGameObject titleScreenSprite = new SpriteGameObject("Sprites/spr_titlescreen");
            // gameObjectsList is a protected variable, so subclasses of GameState can access it. 
            gameObjectsList.AddChild(titleScreenSprite);
            // Add the buttons
            playButton = new Button("Sprites/UI/spr_button_play");
            playButton.LocalPosition = new Vector2(415, 540);
            gameObjectsList.AddChild(playButton);
            optionsButton = new Button("Sprites/UI/spr_button_options");
            optionsButton.LocalPosition = new Vector2(415, 650);
            gameObjectsList.AddChild(optionsButton);
            helpButton = new Button("Sprites/UI/spr_button_help");
            helpButton.LocalPosition = new Vector2(415, 760);
            gameObjectsList.AddChild(helpButton);
        }
        #endregion
        #region Public Methods
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            HandleMouseClicks();
        }
        #endregion
        #region Private Methods
        private void HandleMouseClicks()
        {
            if (playButton.IsPressed)
            {
                ExtendedGame.GameStateManager.SwitchGameState(PenguinPairs.STATENAME_LEVELSELECT);
            }
            if (helpButton.IsPressed)
            {
                ExtendedGame.GameStateManager.SwitchGameState(PenguinPairs.STATENAME_HELP);
            }
            if (optionsButton.IsPressed)
            {
                ExtendedGame.GameStateManager.SwitchGameState(PenguinPairs.STATENAME_OPTIONS);
            }
        }
        #endregion
    }
}
