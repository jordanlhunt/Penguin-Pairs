using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1.Engine
{
    internal class SpriteSheet
    {
        #region Member Variables
        Texture2D sprite;
        Rectangle spriteRectangle;
        int spriteSheetIndex;
        int spriteSheetColumns;
        int spriteSheetRows;
        #endregion
        #region Properties
        /// <summary>
        /// Returns the width of a single sprite in the sheet
        /// </summary>
        public int Width
        {
            get
            {
                return sprite.Width / spriteSheetColumns;
            }
        }
        /// <summary>
        /// Returns the height of a single sprite in the sheet
        /// </summary>
        public int Height
        {
            get
            {
                return sprite.Height / spriteSheetRows;
            }
        }
        /// <summary>
        /// Returns the a Vector2 that represents the center of the single sprite
        /// </summary>
        public Vector2 Center
        {
            get
            {
                return (new Vector2(Width, Height) / 2);
            }
        }
        /// <summary>
        /// Returns a Rectangle with that holds the bounds of the sprite
        /// </summary>
        public Rectangle Bounds
        {
            get
            {
                return new Rectangle(0, 0, Width, Height);
            }
        }
        /// <summary>
        /// Returns an int that countains all of the sprites in a spriteSheet
        /// </summary>
        public int NumberOfSheetElements
        {
            get
            {
                return spriteSheetColumns * spriteSheetRows;
            }
        }
        public int SheetIndex
        {
            get
            {
                return spriteSheetIndex;
            }
            set
            {
                if (value >= 0 && value < NumberOfSheetElements)
                {
                    spriteSheetIndex = value;
                    int columnIndex = spriteSheetIndex % spriteSheetColumns;
                    int rowIndex = spriteSheetIndex / spriteSheetColumns;
                    spriteRectangle = new Rectangle(Width * columnIndex, Height * rowIndex, Width, Height);
                }
            }
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Creates a new spriteSheet object
        /// </summary>
        /// <param name="assetName">The file name, it expects a file name ending in "@WxH" where W is number of sprites wide, and H is the number of sprites height</param>
        /// <param name="sheetIndex">The beginning of the sprite</param>
        public SpriteSheet(string assetName, int sheetIndex = 0)
        {
            sprite = ExtendedGame.AssetManager.LoadSprite(assetName);
            spriteSheetColumns = 1;
            spriteSheetRows = 1;
            string[] assetNameSplit = assetName.Split('@');

            if (assetNameSplit.Length >= 2)
            {
                string sheetWidthAndHeightData = assetNameSplit[assetNameSplit.Length - 1];
                string[] columnAndRow = sheetWidthAndHeightData.Split('x');
                spriteSheetColumns = int.Parse(columnAndRow[0]);
                if (columnAndRow.Length == 2)
                {
                    spriteSheetRows = int.Parse(columnAndRow[1]);
                }
            }
            SheetIndex = sheetIndex;
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Draws the sprite at a position.
        /// </summary>
        /// <param name="spriteBatch">The spriteBatch object used for drawing sprites</param>
        /// <param name="position">A position in the game world to draw</param>
        /// <param name="origin">An origin that should be subtract from the drawing position</param>
        public void Draw(SpriteBatch spriteBatch, Vector2 position, Vector2 origin)
        {
            spriteBatch.Draw(sprite, position, spriteRectangle, Color.White, 0.0f, origin, 1.0f, SpriteEffects.None, 0.0f);
        }
        #endregion
        #region Private Methods
        #endregion

    }
}
