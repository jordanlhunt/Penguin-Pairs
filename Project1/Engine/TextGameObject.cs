using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1.Engine
{
    internal class TextGameObject : GameObject
    {
        #region Member Variables
        /// <summary>
        /// The font to use
        /// </summary>
        protected SpriteFont font;
        /// <summary>
        /// The color to use when drawing the Text
        /// </summary>
        protected Color fontColor;
        protected Alignment fontAlignment;
        #endregion
        #region Properties
        /// <summary>
        /// The text string that this object should draw on the screen
        /// </summary>
        public string TextString
        {
            get; set;
        }
        /// <summary>
        /// An enum that describes the differnet ways in which text can be aligned horizontally
        /// </summary>
        public enum Alignment
        {
            Left, Right, Center
        }
        /// <summary>
        /// Gets the x-coordinate to use as an origin for the drawing the text. This coordinate deponds on the horizontal alignment and width of the text
        /// </summary>
        float OriginX
        {
            get
            {
                // Left aligned
                if (fontAlignment == Alignment.Left)
                {
                    return 0;
                }
                // Right aligned
                if (fontAlignment == Alignment.Right)
                {
                    return font.MeasureString(TextString).X;

                }
                else
                {
                    // Center aligned
                    return font.MeasureString(TextString).X / 2.0f;
                }
            }
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Create a new TextGameObject with given details
        /// </summary>
        /// <param name="fontName">The name of the font to use</param>
        /// <param name="color">The color with which the text should be drawn.</param>
        /// <param name="alignment">The horizontal alignment to use</param>
        public TextGameObject(string fontName, Color color, Alignment alignment = Alignment.Left)
        {
            font = ExtendedGame.AssetManager.LoadFont(fontName);
            fontColor = color;
            fontAlignment = alignment;
            TextString = "DefaultTextABC123";
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Draws the TextGameObject on the screen.
        /// </summary>
        /// <param name="gameTime">An object containing information about hte time that has passed in the game</param>
        /// <param name="spriteBatch">A sprite batch object used for drawing sprites</param>
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (IsVisible)
            {
                return;
            }
            // Calculate the origin
            Vector2 orign = new Vector2(OriginX, 0);
            // Draw the text   
            spriteBatch.DrawString(font, TextString, GlobalPosition, fontColor, 0f, orign, 1, SpriteEffects.None, 0);
        }
        #endregion
        #region Private Methods
        #endregion
    }
}
