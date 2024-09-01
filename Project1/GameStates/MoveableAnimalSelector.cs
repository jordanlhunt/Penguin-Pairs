using Microsoft.Xna.Framework;
using Project1.Engine;
using Project1.LevelObjects;
using Point = Microsoft.Xna.Framework.Point;


namespace Project1.GameStates
{
    internal class MoveableAnimalSelector : GameObjectList
    {
        #region Member Variables
        Arrow[] arrowsArray;
        Point[] directionArray;
        MoveableAnimal selectedAnimal;
        #endregion
        #region Properties
        public MoveableAnimal SelectedAnimal
        {
            get
            {
                return selectedAnimal;
            }
            set
            {
                selectedAnimal = value;
                IsVisible = (selectedAnimal != null);
            }
        }
        #endregion

        #region Constructor
        public MoveableAnimalSelector()
        {
            directionArray = new Point[4];
            directionArray[0] = new Point(1, 0);    // Right 
            directionArray[1] = new Point(0, -1);   // Down
            directionArray[2] = new Point(-1, 0);   // Left
            directionArray[3] = new Point(0, 1);    // Up
            arrowsArray = new Arrow[4];
            for (int i = 0; i < 4; i++)
            {
                arrowsArray[i] = new Arrow(i);
                arrowsArray[i].LocalPosition = new Vector2(directionArray[i].X * arrowsArray[i].Width, directionArray[i].Y * arrowsArray[i].Height);
                AddChild(arrowsArray[i]);
            }
            SelectedAnimal = null;
        }
        #endregion

        #region Public Methods
        public override void HandleInput(InputHelper inputHelper)
        {
            if (SelectedAnimal == null)
            {
                return;
            }
            base.HandleInput(inputHelper);
            for (int i = 0; i < 4; i++)
            {
                if (arrowsArray[i].IsPressed)
                {
                    SelectedAnimal.TryMoveInDirection(directionArray[i]);
                    return;
                }
            }
            if (inputHelper.IsMouseLeftButtonPressed())
            {
                SelectedAnimal = null;
            }
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (SelectedAnimal != null)
            {
                LocalPosition = selectedAnimal.LocalPosition;
                for (int i = 0; i < 4; i++)
                {
                    arrowsArray[i].IsVisible = SelectedAnimal.CanMoveInDirection(directionArray[i]);
                }
            }
        }


        #endregion

        #region Private Methods
        #endregion
    }
}
