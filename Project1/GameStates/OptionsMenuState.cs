using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Project1.Engine;
using Project1.Engine.UserInterface;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace Project1.GameStates
{
    internal class OptionsMenuState : GameState
    {
        #region Member Variables
        Button backButton;
        ToggleButton hintsToggleButton;
        Slider musicVolumeSlider;
        TextGameObject hintsText;
        TextGameObject musicVolumeText;
        #endregion
        #region Properties
        #endregion
        #region Constructor
        public OptionsMenuState()
        {
            // Institiate all the buttons
            SpriteGameObject optionMenuStateSprite = new SpriteGameObject("Sprites/spr_background_options");
            // gameObjectsList is a protected variable, so subclasses of GameState can access it. 
            backButton = new Button("Sprites/UI/spr_button_back");
            hintsToggleButton = new ToggleButton("Sprites/UI/spr_toggle_button@2");
            musicVolumeSlider = new Slider("Sprites/UI/spr_slider_button", "Sprites/UI/spr_slider_bar", 0, 1, 8);
            hintsToggleButton.LocalPosition = new Vector2(650, 340);
            backButton.LocalPosition = new Vector2(415, 720);
            musicVolumeSlider.LocalPosition = new Vector2(650, 500);
            // Add the gameObjects to the the List of gameObjects
            gameObjectsList.AddChild(optionMenuStateSprite);
            gameObjectsList.AddChild(hintsToggleButton);
            gameObjectsList.AddChild(backButton);
            gameObjectsList.AddChild(musicVolumeSlider);
            SetupTextGameObjects();

            musicVolumeSlider.CurrentValue = MediaPlayer.Volume;
            hintsToggleButton.IsSelected = PenguinPairs.HintsEnabled;

        }
        #endregion
        #region Public Methods
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (backButton.IsPressed)
            {
                ExtendedGame.GameStateManager.SwitchGameState(PenguinPairs.STATENAME_TITLE);
            }
            if (hintsToggleButton.IsPressed)
            {
                PenguinPairs.HintsEnabled = hintsToggleButton.IsSelected;
            }
        }
        #endregion
        #region Private Methods
        private void SetupTextGameObjects()
        {
            hintsText = new TextGameObject("Fonts/MenuFont", Color.DarkBlue);
            hintsText.TextString = "Hints";
            hintsText.LocalPosition = new Vector2(150, 340);
            gameObjectsList.AddChild(hintsText);
            musicVolumeText = new TextGameObject("Fonts/MenuFont", Color.DarkBlue);
            musicVolumeText.TextString = "Music Volume";
            musicVolumeText.LocalPosition = new Vector2(150, 480);
            gameObjectsList.AddChild(musicVolumeText);
        }
        #endregion
    }
}
