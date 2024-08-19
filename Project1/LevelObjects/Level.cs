using Microsoft.Xna.Framework;
using Project1.Engine;
using System.Collections.Generic;
using System.IO;

namespace Project1.LevelObjects
{
    internal class Level : GameObjectList
    {
        #region Constants
        const int TileWidth = 73;
        const int TileHeight = 72;
        const string MoveableAnimalLetters = "brgycpmx";
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
            List<string> gridRows = new List<string>();
            string gridLine = streamReader.ReadLine();
            int gridWidth = gridLine.Length;
            while (gridLine != null)
            {
                gridRows.Add(gridLine);
                gridLine = streamReader.ReadLine();
                if (gridLine.Length > gridWidth)
                {
                    gridWidth = gridLine.Length;
                }
            }
            streamReader.Close();
            AddPlayingField(gridRows, gridWidth, gridRows.Count);
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
        /// <summary>
        /// This method will convert text of a level file to a grid filled with instances of the Tile and Animal classes
        /// </summary>
        /// <param name="gridRows"></param>
        /// <param name="gridWidth"></param>
        /// <param name="gridHeight"></param>
        void AddPlayingField(List<string> gridRows, int gridWidth, int gridHeight)
        {
            GameObjectList playingFieldList = new GameObjectList();
            Vector2 gridSize = new Vector2(gridWidth * TileWidth, gridHeight * TileHeight);
            playingFieldList.LocalPosition = new Vector2(600, 420) - gridSize / 2.0f;
            tiles = new Tile[gridWidth, gridHeight];
            animalsOnTiles = new Animal[gridWidth, gridHeight];
            for (int y = 0; y < gridHeight; y++)
            {
                string row = gridRows[y];
                for (int x = 0; x < gridWidth; x++)
                {
                    char symbol = ' ';
                    if (x < row.Length)
                    {
                        symbol = row[x];
                    }
                    AddTile(x, y, symbol);
                    AddAnimal(x, y, symbol);
                }

            }
            for (int y = 0; y < gridHeight; y++)
            {
                for (int x = 0; x < gridWidth; x++)
                {
                    playingFieldList.AddChild(tiles[x, y]);
                }
            }
            for (int y = 0; y < gridHeight; y++)
            {
                for (int x = 0; x < gridWidth; x++)
                {
                    if (animalsOnTiles[x, y] != null)
                    {
                        playingFieldList.AddChild(animalsOnTiles[x, y]);
                    }
                }
            }
            hintArrow.IsVisible = false;
            playingFieldList.AddChild(hintArrow);
            AddChild(playingFieldList);
        }

        private void AddAnimal(int x, int y, char symbol)
        {
            Animal newAnimal = null;
            // TODO: check if symbol represents an animal
            if (symbol == '@')
            {
                newAnimal = new Shark();
            }
            if (newAnimal == null)
            {
                int animalIndex = MoveableAnimalLetters.IndexOf(symbol);
                if (animalIndex >= 0)
                {
                    newAnimal = new MoveableAnimal(animalIndex, false);
                }
            }
            if (newAnimal == null)
            {
                int animalIndex = MoveableAnimalLetters.ToUpper().IndexOf(symbol);
                if (animalIndex >= 0)
                {
                    newAnimal = new MoveableAnimal(animalIndex, true);
                }
            }

            if (newAnimal != null)
            {
                newAnimal.LocalPosition = GetCellPosition(x, y);
                animalsOnTiles[x, y] = newAnimal;
            }
        }

        private void AddTile(int x, int y, char symbol)
        {
            Tile tile = new Tile(CharToTileType(symbol), x, y);
            tile.LocalPosition = GetCellPosition(x, y);
            tiles[x, y] = tile;
        }
        private Tile.Type CharToTileType(char symbol)
        {
            if (symbol == ' ')
            {
                return Tile.Type.Empty;
            }
            else if (symbol == '.')
            {
                return Tile.Type.Normal;
            }
            else if (symbol == '#')
            {
                return Tile.Type.Wall;
            }
            else if (symbol == '_')
            {
                return Tile.Type.Hole;
            }
            else if (MoveableAnimalLetters.ToUpper().Contains(symbol))
            {
                return Tile.Type.Hole;
            }
            return Tile.Type.Normal;
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