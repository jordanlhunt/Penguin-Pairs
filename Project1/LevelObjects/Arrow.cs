using Project1.Engine;
using Project1.Engine.UserInterface;


namespace Project1.LevelObjects
{

    internal class Arrow : Button
    {
        #region Member Variables
        SpriteSheet normalSprite, hoverSprite;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public Arrow(int sheetIndex) : base("Sprites/LevelObjects/spr_arrow1@4")
        {
            SheetIndex = sheetIndex;
            normalSprite = sprite;
            hoverSprite = new SpriteSheet("Sprites/LevelObjects/spr_arrow2@4", sheetIndex);
        }
        #endregion

        #region Public Methods
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (BoundingBox.Contains(inputHelper.MousePositionWorld))
            {
                sprite = hoverSprite;
            }
            else
            {
                sprite = normalSprite;
            }
        }
        #endregion

        #region Private Methods
        #endregion
    }
}
