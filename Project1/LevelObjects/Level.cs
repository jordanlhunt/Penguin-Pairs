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
        }
        void CreateLevelInfoObject(string levelTitle, string levelDescription)
        {
            SpriteGameObject spriteGameObject = new SpriteGameObject("Sprites/spr_level_info");
            TextGameObject textGameObjectInfo = new TextGameObject("Fonts/HelpFont", Color.DarkMagenta);
            TextGameObject textGameObjectDescription = new TextGameObject("Fonts/HelpFont", Color.DarkMagenta);
            textGameObjectInfo.Text = levelTitle;
            textGameObjectDescription.Text = levelDescription;


        }
        #endregion
    }
}
