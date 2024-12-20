﻿using Microsoft.Xna.Framework;
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
        Point startPosition;
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
        bool IsSeal
        {
            get
            {
                return AnimalIndex == 7;
            }
        }
        bool IsMultiColoredPenguin
        {
            get
            {
                return AnimalIndex == 6;
            }
        }
        #endregion
        #region Constructor
        public MoveableAnimal(Level level, Point gridPosition, int animalIndex) : base(level, gridPosition, GetSpriteName(false), animalIndex)
        {
            this.targetWorldPosition = LocalPosition;
            this.startPosition = gridPosition;
        }
        #endregion
        #region Public Methods
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (IsMoving && Vector2.Distance(LocalPosition, targetWorldPosition) < SPEED * gameTime.ElapsedGameTime.TotalSeconds)
            {
                ApplyCurrentPosition();
            }
        }
        public void TryMoveInDirection(Point movementDirection)
        {
            // Move the animal as long it can move in a direciton
            Point positionBeforeMoving = currentGridPosition;
            while (CanMoveInDirection(movementDirection))
            {
                currentGridPosition += movementDirection;
            }
            if (currentGridPosition != positionBeforeMoving)
            {
                targetWorldPosition = level.GetCellPosition(currentGridPosition.X, currentGridPosition.Y);
                Vector2 direction = targetWorldPosition - LocalPosition;
                direction.Normalize();
                velocity = direction * SPEED;
                level.RemoveAnimalFromGrid(positionBeforeMoving);
            }
        }
        /// <summary>
        /// Checks and returns whether this MovableAnimal can move (at least one grid cell) in the given direction. 
        /// Moving in this direction might cause the MovableAnimal to die, but that doesn't matter here.
        /// </summary>
        /// <param name="direction">A direction to move in.</param>
        /// <returns>true if the animal can move in the given direction; false otherwise.</returns>
        public bool CanMoveInDirection(Point movementDirection)
        {
            bool canMoveInDirection = true;
            if (!IsVisible || IsInHole || IsMoving)
            {
                canMoveInDirection = false;
            }
            // Get information about the current tile
            Tile.Type currentTileType = level.GetTileType(currentGridPosition);
            Animal otherAnimal = level.GetAnimal(currentGridPosition);
            // If current tile has "empty" or hole type, the animal should stop moving
            if (currentTileType == Tile.Type.Empty || currentTileType == Tile.Type.Hole)
            {
                canMoveInDirection = false;
            }
            // If another animal is at the current tile there should be some interaction not a movement
            if (otherAnimal != null && otherAnimal != this)
            {
                canMoveInDirection = false;
            }
            // Check the next tile
            Point nextTilePosition = currentGridPosition + movementDirection;
            Tile.Type nextTileType = level.GetTileType(nextTilePosition);
            Animal nextAnimal = level.GetAnimal(nextTilePosition);
            // If next tile is a wall, don't allow movement
            if (nextTileType == Tile.Type.Wall)
            {
                canMoveInDirection = false;
            }
            // If the next tile contains a movable animal that doesn't match, we can't go there
            if (nextAnimal is MoveableAnimal && !IsPairWith((MoveableAnimal)nextAnimal))
            {
                canMoveInDirection = false;
            }
            return canMoveInDirection;
        }
        public override void HandleInput(InputHelper inputHelper)
        {
            if (IsVisible && BoundingBox.Contains(inputHelper.MousePositionWorld) && inputHelper.IsMouseLeftButtonPressed())
            {
                level.SelectAnimal(this);
            }
        }
        protected override void ApplyCurrentPosition()
        {
            // Set the animal's local position to the world position
            LocalPosition = level.GetCellPosition(currentGridPosition.X, currentGridPosition.Y);
            velocity = Vector2.Zero;
            Tile.Type currentTileType = level.GetTileType(currentGridPosition);
            if (currentTileType == Tile.Type.Empty)
            {
                IsVisible = false;
            }
            Animal otherAnimal = level.GetAnimal(currentGridPosition);
            if (otherAnimal != null)
            {
                level.RemoveAnimalFromGrid(currentGridPosition);
                IsVisible = false;
                otherAnimal.IsVisible = false;
                if (otherAnimal is MoveableAnimal)
                {
                    level.PairFound(this, (MoveableAnimal)otherAnimal);
                }
            }
            level.AddAnimalToGrid(this, currentGridPosition);
            if (currentTileType == Tile.Type.Hole)
            {
                isInHole = true;
            }
        }
        public override void Reset()
        {
            currentGridPosition = startPosition;
            isInHole = false;
            base.Reset();
            targetWorldPosition = LocalPosition;
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
        bool IsPairWith(MoveableAnimal otherAnimal)
        {
            bool isPairWith = true;
            // if either of them are seals return false
            if (this.IsSeal || otherAnimal.IsSeal)
            {
                isPairWith = false;
            }
            // If either of them is a multicolored penguin then return true
            if (!(this.IsMultiColoredPenguin) && !(otherAnimal.IsMultiColoredPenguin))
            {
                isPairWith = false;
            }
            isPairWith = (this.AnimalIndex == otherAnimal.AnimalIndex);
            return isPairWith;
        }
        #endregion
    }
}
