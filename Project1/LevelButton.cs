using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Engine;
using Project1.Engine.UserInterface;

namespace Project1
{
    internal class LevelButton : Button
    {
        #region Member Variables
        LevelStatus levelStatus;
        TextGameObject textGameObjectLabel;
        #endregion
        #region Properties
        public int LevelIndex
        {
            get; private set;
        }
        public LevelStatus CurrentStatus
        {
            get
            {
                return levelStatus;
            }
            set
            {
                levelStatus = value;
                sprite = new SpriteSheet(GetSpriteNameForStatus(levelStatus));
                SheetIndex = (LevelIndex - 1) % sprite.NumberOfSheetElements;
            }
        }
        #endregion
        #region Constructor
        public LevelButton(int levelIndex, LevelStatus startStatus) : base(GetSpriteNameForStatus(startStatus))
        {
            LevelIndex = levelIndex;
            levelStatus = startStatus;
            // Add a label that shows the level Index
            textGameObjectLabel = new TextGameObject("Fonts/ScoreFont", Color.Black, TextGameObject.Alignment.Left);
            textGameObjectLabel.LocalPosition = sprite.Center + new Vector2(0, 12);
            textGameObjectLabel.Parent = this;
            textGameObjectLabel.Text = levelIndex.ToString();
        }
        #endregion
        #region Public Methods
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            textGameObjectLabel.Draw(gameTime, spriteBatch);
        }
        #endregion
        #region Private Methods
        private static string GetSpriteNameForStatus(LevelStatus status)
        {
            string statusString = "";
            if (status == LevelStatus.Locked)
            {
                statusString = "Sprites/UI/spr_level_locked";
            }
            if (status == LevelStatus.Unlocked)
            {
                statusString = "Sprites/UI/spr_level_unsolved";
            }
            else
            {
                statusString = "Sprites/UI/spr_level_solved@6";
            }
            return statusString;
        }
        #endregion
    }
}
