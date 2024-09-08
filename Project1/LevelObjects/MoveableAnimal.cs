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
            if (!CanMoveInDirection(movementDirection))
            {
                return;
            }
            level.RemoveAnimalFromGrid(currentGridPosition);
            while (CanMoveInDirection(movementDirection))
            {
                currentGridPosition += movementDirection;
            }
            targetWorldPosition = level.GetCellPosition(currentGridPosition.X, currentGridPosition.Y);
            Vector2 direction = targetWorldPosition - LocalPosition;
            direction.Normalize();
            velocity = direction * SPEED;
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
