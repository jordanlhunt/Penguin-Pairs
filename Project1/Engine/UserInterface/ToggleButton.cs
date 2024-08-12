namespace Project1.Engine.UserInterface
{
    internal class ToggleButton : Button
    {
        #region Member Variables
        bool isSelected;
        #endregion
        #region Properties
        public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                isSelected = value;
                if (isSelected)
                {
                    SheetIndex = 1;
                }
                else
                {
                    SheetIndex = 0;
                }
            }
        }
        #endregion
        #region Constructor
        public ToggleButton(string assetName) : base(assetName)
        {
            IsSelected = false;
        }
        #endregion
        #region Public Methods
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (IsPressed)
            {
                IsSelected = !IsSelected;
            }
        }
        public override void Reset()
        {
            base.Reset();
            IsSelected = false;
        }
        #endregion
        #region Private Methods
        #endregion

    }
}
