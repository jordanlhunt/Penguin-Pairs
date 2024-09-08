using Point = Microsoft.Xna.Framework.Point;
namespace Project1.LevelObjects
{
    internal class Shark : Animal
    {
        public Shark(Level level, Point gridPosition) : base(level, gridPosition, "Sprites/LevelObjects/spr_shark")
        {
        }
    }
}
