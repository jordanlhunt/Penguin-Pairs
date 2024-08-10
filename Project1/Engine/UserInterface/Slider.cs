using Microsoft.Xna.Framework;

namespace Project1.Engine.UserInterface
{
    internal class Slider : GameObjectList
    {
        #region Member variables
        SpriteGameObject backgroundBar;
        SpriteGameObject foregroundBar;
        float maximumValue;
        float minimumValue;
        float currentValue;
        float previousValue;
        int backgroundPadding;
        #endregion
        #region Properties
        float MinimumLocalX
        {
            get
            {
                return backgroundPadding + foregroundBar.Width / 2;
            }
        }
        float MaximumLocalX
        {
            get
            {
                return foregroundBar.Width - backgroundPadding - foregroundBar.Width / 2;
            }
        }

        float CurrentValue
        {
            get
            {
                return currentValue;
            }
            set
            {
                currentValue = MathHelper.Clamp(value, minimumValue, maximumValue);
                float fraction = (currentValue - minimumValue) / Range;
                float newForgroundBarX = MinimumLocalX + fraction * AviableWidth;
                foregroundBar.LocalPosition = new Vector2(newForgroundBarX, backgroundPadding);
            }
        }

        public float Range
        {
            get
            {
                return (maximumValue - minimumValue);
            }
        }
        public float AviableWidth
        {
            get
            {
                return MaximumLocalX - MinimumLocalX;
            }
        }
        bool IsValueChanged
        {
            get
            {
                return previousValue == currentValue;
            }
        }
        #endregion
        #region Constructor
        public Slider(string foregroundSprite, string backgroundSprite, float maximumValue, float minimumValue)
        {
            backgroundBar = new SpriteGameObject(backgroundSprite);
            AddChild(backgroundBar);

            foregroundBar = new SpriteGameObject(foregroundSprite);
            foregroundBar.Origin = new Vector2(foregroundBar.Width / 2, 0);
            AddChild(foregroundBar);

            this.minimumValue = minimumValue;
            this.maximumValue = maximumValue;
            previousValue = this.minimumValue;
            currentValue = previousValue;

        }
        #endregion
        #region Public Methods
        public override void HandleInput(InputHelper inputHelper)
        {
            if (IsVisible == false)
            {
                return;
            }
            Vector2 currentMousePosition = inputHelper.MousePositionWorld;
            previousValue = currentValue;
            if (inputHelper.IsMouseLeftButtonDown() && foregroundBar.BoundingBox.Contains(currentMousePosition))
            {
                float mouseXInRange = currentMousePosition.X - GlobalPosition.X - MinimumLocalX;
                float newFraction = mouseXInRange / AviableWidth;
                CurrentValue = newFraction * Range + minimumValue;
            }
        }
        #endregion
        #region Private Methods
        #endregion
    }
}
