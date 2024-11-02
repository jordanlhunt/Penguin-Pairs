using Project1.Engine;
using Point = Microsoft.Xna.Framework.Point;
namespace Project1.LevelObjects
{
    internal abstract class Animal : SpriteGameObject
    {
        protected Level level;
        protected Point currentGridPosition;
        protected Animal(Level level, Point gridPosition, string spriteName, int sheetIndex = 0) : base(spriteName, sheetIndex)
        {
            this.level = level;
            this.currentGridPosition = gridPosition;
            ApplyCurrentPosition();
        }
        protected virtual void ApplyCurrentPosition()
        {

            LocalPosition = level.GetCellPosition(currentGridPosition.X, currentGridPosition.Y);
            level.AddAnimalToGrid(this, currentGridPosition);
        }
    }
}
