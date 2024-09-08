using Microsoft.Xna.Framework;
using Project1.Engine;

namespace Project1.LevelObjects
{
    internal class MoveableAnimal : Animal
    {
        #region Constants
        const float SPEED = 300.0f;
        #endregion
        #region Member Variables
        bool isInHole;
        Vector2 targetWorldPosition;
        #endregion
        #region Properties
        public int AnimalIndex
        {
            get
            {
                return SheetIndex;
            }
        }
        bool IsInHole
        {
            get
            {
                return isInHole;
            }
            set
            {
                isInHole = value;
                sprite = new SpriteSheet(GetSpriteName(isInHole), AnimalIndex);
            }
        }
        bool IsMoving
        {
            get
            {
                return LocalPosition != targetWorldPosition;
            }
        }
        #endregion
        #region Constructor
        public MoveableAnimal(Level level, Point gridPosition, int animalIndex, bool isInHole) : base(level, gridPosition, GetSpriteName(isInHole), animalIndex)
        {
            this.targetWorldPosition = LocalPosition;

        }
        #endregion
        #region Public Methods


        public void TryMoveInDirection(Point movementDirection)
        {
        }

        public bool CanMoveInDirection(Point movementDirection)
        {
            return true;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            if (IsVisible && BoundingBox.Contains(inputHelper.MousePositionWorld) && inputHelper.IsMouseLeftButtonPressed())
            {
                level.SelectAnimal(this);
            }
        }
        #endregion

        #region Private Methods
        static string GetSpriteName(bool isInHole)
        {
            if (isInHole)
            {
                return "Sprites/LevelObjects/spr_penguin_boxed@8";
            }
            else
            {
                return "Sprites/LevelObjects/spr_penguin@8";
            }
        }
        #endregion
    }
}
