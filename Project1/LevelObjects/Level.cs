using Microsoft.Xna.Framework;
using Project1.Engine;
using System.IO;

namespace Project1.LevelObjects
{
    internal class Level : GameObjectList
    {
        #region Constants
        const int TileWidth = 73;
        const int TileHeight = 72;
        #endregion
        #region Member Variables
        int targetNumberOfPairs;
        Tile[,] tiles;
        Animal[,] animalsOnTiles;
        SpriteGameObject hintArrow;
        #endregion
        #region Properties
        public int LevelIndex
        {
            get;
            private set;
        }
        #endregion
        #region Constructor
        public Level(int levelIndex, string fileName)
        {
            this.LevelIndex = levelIndex;
            LoadLevelFromFileName(fileName);
        }
        #endregion
        #region Public Method
        public Vector2 GetCellPosition(int x, int y)
        {
            return new Vector2(x * TileWidth, y * TileHeight);
        }
        #endregion
        #region Private Method
        void LoadLevelFromFileName(string fileName)
        {
            StreamReader streamReader = new StreamReader(fileName);
            string levelTitle = streamReader.ReadLine();
            string levelDescription = streamReader.ReadLine();
            targetNumberOfPairs = int.Parse(streamReader.ReadLine());
            CreateLevelInfoObject(levelTitle, levelDescription);
            string[] hint = streamReader.ReadLine().Split(' ');
            int hintX = int.Parse(hint[0]);
            int hintY = int.Parse(hint[1]);
            int hintDirection = StringToDirection(hint[2]);
            hintArrow = new SpriteGameObject("spr_arrow_hint@4", hintDirection);
            hintArrow.LocalPosition = GetCellPosition(hintX, hintY);
        }
        void CreateLevelInfoObject(string levelTitle, string levelDescription)
        {
            SpriteGameObject levelInfoBackground = new SpriteGameObject("Sprites/spr_level_info");
            levelInfoBackground.SetOriginToCenter();
            levelInfoBackground.LocalPosition = new Vector2(600, 820);
            TextGameObject textGameObjectInfo = new TextGameObject("Fonts/HelpFont", Color.DarkMagenta);
            TextGameObject textGameObjectDescription = new TextGameObject("Fonts/HelpFont", Color.DarkMagenta);
            textGameObjectInfo.Text = levelTitle;
            textGameObjectDescription.Text = levelDescription;
            textGameObjectInfo.LocalPosition = new Vector2(600, 800);
            textGameObjectDescription.LocalPosition = new Vector2(600, 786);
            AddChild(levelInfoBackground);
            AddChild(textGameObjectDescription);
            AddChild(textGameObjectInfo);
        }
        int StringToDirection(string direction)
        {
            if (direction == "right")
            {
                return (int)ArrowDirection.Right;
            }
            else if (direction == "up")
            {
                return (int)ArrowDirection.Up;
            }
            else if (direction == "left")
            {
                return (int)ArrowDirection.Left;
            }
            else
            {
                return (int)ArrowDirection.Down;
            }
        }
        #endregion
    }
}
enum ArrowDirection
{
    Right,
    Up,
    Left,
    Down
}