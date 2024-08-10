namespace Project1.Engine.UserInterface
{
    internal class Button : SpriteGameObject
    {
        #region Member Variables
        #endregion
        #region Properties
        public bool IsPressed
        {
            get; protected set;
        }
        #endregion
        #region Constructor
        public Button(string assetName) : base(assetName)
        {
            // All buttons should be set to false on creation, Only set to true if the button is visible and left mouse button is being pressed and the mouse pointer lies inside the button's boundingBox

            IsPressed = false;
        }
        #endregion
        #region Public Methods
        public override void HandleInput(InputHelper inputHelper)
        {
            IsPressed = IsVisible && inputHelper.IsMouseLeftButtonPressed() && BoundingBox.Contains(inputHelper.MousePositionWorld);
        }
        public override void Reset()
        {
            base.Reset();
            IsPressed = false;
        }
        #endregion
        #region Private Methods
        #endregion

    }
}
