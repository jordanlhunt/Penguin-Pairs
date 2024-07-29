using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace Project1.Engine
{
    internal class SpriteGameObject : GameObject
    {
        #region Member Variables
        /// <summary>
        /// The sprite that this object can draw on the screen
        /// </summary>
        protected Texture2D sprite;
        /// <summary>
        /// The origin ('offset') to use when drawing the sprite to the screen.
        /// </summary>
        protected Vector2 origin;
        #endregion
        #region Properties
        /// <summary>
        /// Gets the width of this object in the game world, according to its sprite
        /// </summary>
        public int Width
        {
            get
            {
                return sprite.Width;
            }
        }
        /// <summary>
        /// Gets the height of this object in the game world, according to its sprite
        /// </summary>
        public int Height
        {
            get
            {
                return sprite.Height;
            }
        }
        public Rectangle BoundingBox
        {
            get
            {
                // get the sprites Bounds 
                Rectangle spriteBounds = sprite.Bounds;
                // add the object's position to it as an offset
                spriteBounds.Offset(GlobalPosition - origin);
                return spriteBounds;
            }
        }

        #endregion
        #region Constructors
        /// <summary>
        /// Creates a new SpriteGameObject with a given sprite Name 
        /// </summary>
        /// <param name="spriteName">The string of sprite to load</param>
        public SpriteGameObject(string spriteName)
        {
            sprite = ExtendedGame.AssetManager.LoadSprite(spriteName);
            origin = Vector2.Zero;
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Draws this SpriteGameObject on the screen, using its GlobalPosition property and origin. Note the object will only get drawn if it's actually marked as visible
        /// </summary>
        /// <param name="gameTime">An object containing information about the time that has passed</param>
        /// <param name="spriteBatch">A spriteBatch object used for drawing sprites</param>
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (IsVisible == true)
            {
                // Draw the sprite at its GLOBAL position in the game world
                spriteBatch.Draw(sprite, GlobalPosition, null, Color.White, 0, origin, 1.0f, SpriteEffects.None, 0);
            }
            base.Draw(gameTime, spriteBatch);
        }
        /// <summary>
        /// Update this object's origin so it lies in the center of the sprite
        /// </summary>
        public void SetOriginToCenter()
        {
            origin = new Vector2(Width / 2.0f, Height / 2.0f);
        }
        #endregion
        #region Private Methods
        #endregion
    }
}
