using Microsoft.Xna.Framework.Graphics;
using Project1.Engine;
using Project1.Engine.UserInterface;
using Project1.LevelObjects;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace Project1.GameStates
{
    internal class PlayingState : GameState
    {
        #region Member Variables
        Button hintButton;
        Button retryButton;
        Button quitButton;
        Level level;
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
                level.ShowHint();
            }
            if (quitButton.IsPressed)
            {
                ExtendedGame.GameStateManager.SwitchGameState(PenguinPairs.STATENAME_LEVELSELECT);
            }
            if (level != null)
            {
                level.HandleInput(inputHelper);
            }
        }
        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
            if (level != null)
            {
                level.Update(gameTime);
            }
            hintButton.IsVisible = PenguinPairs.HintsEnabled && !level.HasFirstMoveBeenMade;
            retryButton.IsVisible = level.HasFirstMoveBeenMade;
        }
        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            if (level != null)
            {
                level.Draw(gameTime, spriteBatch);
            }
        }

        public void LoadLevel(int levelIndex)
        {
            string levelFileName = "Content/Levels/level" + levelIndex + ".txt";
            level = new Level(levelIndex, levelFileName);
            hintButton.IsVisible = PenguinPairs.HintsEnabled;
        }
        #endregion
        #region Private Methods
        #endregion
    }
}
