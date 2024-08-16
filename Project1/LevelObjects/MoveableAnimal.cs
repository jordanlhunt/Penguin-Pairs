using Project1.Engine;

namespace Project1.LevelObjects
{
    internal class MoveableAnimal : Animal
    {
        #region Member Variables
        bool isInHole;
        int animalIndex;
        int sheetIndex;
        #endregion
        #region Properties
        public int AnimalIndex
        {
            get
            {
                return SheetIndex;
            }
        }
        bool IsIneHole
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
        #endregion
        #region Constructor
        public MoveableAnimal(int animalIndex, bool isInHole) : base(GetSpriteName(isInHole), animalIndex)
        {


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
