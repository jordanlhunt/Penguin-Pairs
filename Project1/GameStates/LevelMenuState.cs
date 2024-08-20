using Project1.Engine;
using Project1.Engine.UserInterface;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace Project1.GameStates
{
    internal class LevelMenuState : GameState
    {
        #region Member Variables
        Button backButton;
        LevelButton[] levelButtons;
        #endregion
        #region Properties
        #endregion
        #region Constructor
        public LevelMenuState()
        {
            SpriteGameObject levelMenuStateSprite = new SpriteGameObject("Sprites/spr_background_levelselect");
            // gameObjectsList is a protected variable, so subclasses of GameState can access it. 
            gameObjectsList.AddChild(levelMenuStateSprite);
            backButton = new Button("Sprites/UI/spr_button_back");
            backButton.LocalPosition = new Vector2(415, 720);
            gameObjectsList.AddChild(backButton);
            // Add the level buttons
            int numberOfLevels = PenguinPairs.NumberOfLevels;
            levelButtons = new LevelButton[numberOfLevels];
            // Place the level buttons in a grid
            Vector2 gridOffset = new Vector2(155, 230);
            const int ButtonsPerRow = 5;
            const int SpaceBetweenColumns = 30;
            const int SpaceBetweenRows = 5;
            for (int i = 0; i < numberOfLevels; i++)
            {
                LevelButton levelButton = new LevelButton(i + 1, PenguinPairs.GetLevelStatus(i + 1));
                int buttonRow = i / ButtonsPerRow;
                int buttonColumn = i % ButtonsPerRow;
                levelButton.LocalPosition = gridOffset + new Vector2(buttonColumn * (levelButton.Width + SpaceBetweenColumns), buttonRow * (levelButton.Height + SpaceBetweenRows));
                gameObjectsList.AddChild(levelButton);
                levelButtons[i] = levelButton;
            }

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
            foreach (LevelButton levelButton in levelButtons)
            {
                if (levelButton.IsPressed && levelButton.CurrentStatus != LevelStatus.Locked)
                {
                    // Go to the playing state
                    ExtendedGame.GameStateManager.SwitchGameState(PenguinPairs.STATENAME_PLAYING);
                    PlayingState playingState = (PlayingState)ExtendedGame.GameStateManager.GetGameState(PenguinPairs.STATENAME_PLAYING);
                    playingState.LoadLevel(levelButton.LevelIndex);
                    return;
                }
            }
        }
        #endregion
        #region Private Methods
        #endregion
    }
}
