using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Engine;
namespace Project1.LevelObjects
{
    internal class Tile : GameObject
    {
        #region Enum
        public enum Type
        {
            Normal,
            Empty,
            Wall,
            Hole
        };
        #endregion
        #region Member Variables
        SpriteGameObject tileImage;
        #endregion
        #region Properties
        public Type TileType
        {
            get;
            private set;
        }
        #endregion
        #region Constructor
        public Tile(Type type, int x, int y)
        {
            TileType = type;
            // Add an Image depend on the type
            if (type == Type.Wall)
            {
                tileImage = new SpriteGameObject("Sprites/LevelObjects/spr_wall");
            }
            else if (type == Type.Hole)
            {
                tileImage = new SpriteGameObject("Sprites/LevelObjects/spr_hole");
            }
            else if (type == Type.Normal)
            {
                tileImage = new SpriteGameObject("Sprites/LevelObjects/spr_field@2", (x + y) % 2);
            }
            if (tileImage != null)
            {
                tileImage.Parent = this;
            }
        }
        #endregion
        #region Public Methods
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            tileImage.Draw(gameTime, spriteBatch);
        }
        #endregion
        #region Private Methods
        #endregion
    }
}
