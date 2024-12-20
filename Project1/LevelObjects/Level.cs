﻿using Microsoft.Xna.Framework;
using Project1.Engine;
using Project1.GameStates;
using System.Collections.Generic;
using System.IO;

namespace Project1.LevelObjects
{
    internal class Level : GameObjectList
    {
        #region Constants
        const int TILE_WIDTH = 73;
        const int TILE_HEIGHT = 72;
        const string MOVEABLE_ANIMAL_LETTERS = "brgycpmx";
        #endregion
        #region Member Variables
        int targetNumberOfPairs;
        Tile[,] tiles;
        Animal[,] animalsOnTiles;
        SpriteGameObject hintArrow;
        MoveableAnimalSelector moveableAnimalSelector;
        PairList pairList;
        VisibilityTimer hintTimer;
        #endregion
        #region Properties
        public int LevelIndex
        {
            get;
            private set;
        }
        int GridWidth
        {
            get
            {
                return tiles.GetLength(0);
            }
        }
        int GridHeight
        {
            get
            {
                return tiles.GetLength(1);
            }
        }
        public bool HasFirstMoveBeenMade
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
            // Private Set can only be set in the class constructor
            HasFirstMoveBeenMade = false;
        }
        #endregion
        #region Public Method
        public Vector2 GetCellPosition(int x, int y)
        {
            return new Vector2(x * TILE_WIDTH, y * TILE_HEIGHT);
        }
        public void SelectAnimal(MoveableAnimal someAnimal)
        {
            moveableAnimalSelector.SelectedAnimal = someAnimal;
        }
        public void AddAnimalToGrid(Animal animal, Point gridPosition)
        {
            animalsOnTiles[gridPosition.X, gridPosition.Y] = animal;
        }
        public void RemoveAnimalFromGrid(Point gridPosition)
        {
            animalsOnTiles[gridPosition.X, gridPosition.Y] = null;
            if (HasFirstMoveBeenMade == false)
            {
                HasFirstMoveBeenMade = true;
            }
        }
        public Tile.Type GetTileType(Point gridPosition)
        {
            Tile.Type tileTypeToReturn;
            if (!IsPositionInGrid(gridPosition))
            {
                tileTypeToReturn = Tile.Type.Empty;
            }
            else
            {
                tileTypeToReturn = tiles[gridPosition.X, gridPosition.Y].TileType;
            }
            return tileTypeToReturn;
        }
        public Animal GetAnimal(Point gridPosition)
        {
            Animal animalToReturn;
            if (!IsPositionInGrid(gridPosition))
            {
                animalToReturn = null;
            }
            animalToReturn = animalsOnTiles[gridPosition.X, gridPosition.Y];
            return animalToReturn;
        }
        public void PairFound(MoveableAnimal penguin1, MoveableAnimal penguin2)
        {
            // Calculate the sprite sheet index of the pair that needs to be added
            int penguinType = MathHelper.Max(penguin1.AnimalIndex, penguin2.AnimalIndex);
            pairList.AddPair(penguinType);
        }
        public void ShowHint()
        {
            hintTimer.StartVisible(2);
        }
        public override void Reset()
        {
            for (int y = 0; y < GridHeight; y++)
            {
                for (int x = 0; x < GridWidth; x++)
                {
                    animalsOnTiles[x, y] = null;
                }
            }
            HasFirstMoveBeenMade = false;
            base.Reset();
        }
        #endregion
        #region Private Method
        private void LoadLevelFromFileName(string fileName)
        {
            StreamReader streamReader = new StreamReader(fileName);
            string levelTitle = streamReader.ReadLine();
            string levelDescription = streamReader.ReadLine();
            targetNumberOfPairs = int.Parse(streamReader.ReadLine());
            CreateLevelInfoObjects(levelTitle, levelDescription);
            string[] hint = streamReader.ReadLine().Split(' ');
            int hintX = int.Parse(hint[0]);
            int hintY = int.Parse(hint[1]);
            int hintDirection = StringToDirection(hint[2]);
            hintArrow = new SpriteGameObject("Sprites/LevelObjects/spr_arrow_hint@4", hintDirection);
            hintArrow.LocalPosition = GetCellPosition(hintX, hintY);
            List<string> gridRows = new List<string>();
            string gridLine = streamReader.ReadLine();
            int gridWidth = gridLine.Length;
            while (gridLine != null)
            {
                if (gridLine.Length > gridWidth)
                {
                    gridWidth = gridLine.Length;
                }
                gridRows.Add(gridLine);
                gridLine = streamReader.ReadLine();
            }

            streamReader.Close();
            AddPlayingField(gridRows, gridWidth, gridRows.Count);
        }
        private void CreateLevelInfoObjects(string levelTitle, string levelDescription)
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
            pairList = new PairList(targetNumberOfPairs);
            pairList.LocalPosition = new Vector2(20, 20);
            AddChild(pairList);
        }
        private int StringToDirection(string direction)
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
        private void AddPlayingField(List<string> gridRows, int gridWidth, int gridHeight)
        {
            GameObjectList playingFieldList = new GameObjectList();
            Vector2 gridSize = new Vector2(gridWidth * TILE_WIDTH, gridHeight * TILE_HEIGHT);
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
            hintTimer = new VisibilityTimer(hintArrow);
            moveableAnimalSelector = new MoveableAnimalSelector();
            playingFieldList.AddChild(moveableAnimalSelector);
            AddChild(playingFieldList);
        }

        private void AddAnimal(int x, int y, char symbol)
        {
            Animal newAnimal = null;
            // TODO: check if symbol represents an animal
            if (symbol == '@')
            {
                newAnimal = new Shark(this, new Point(x, y));
            }
            if (newAnimal == null)
            {
                int animalIndex = MOVEABLE_ANIMAL_LETTERS.IndexOf(symbol);
                if (animalIndex >= 0)
                {
                    newAnimal = new MoveableAnimal(this, new Point(x, y), animalIndex);
                }
            }
            if (newAnimal == null)
            {
                int animalIndex = MOVEABLE_ANIMAL_LETTERS.ToUpper().IndexOf(symbol);
                if (animalIndex >= 0)
                {
                    newAnimal = new MoveableAnimal(this, new Point(x, y), animalIndex);
                }
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
            else if (MOVEABLE_ANIMAL_LETTERS.ToUpper().Contains(symbol))
            {
                return Tile.Type.Hole;
            }
            return Tile.Type.Normal;
        }

        private bool IsPositionInGrid(Point gridPosition)
        {
            return (gridPosition.X >= 0 && gridPosition.X < GridWidth && gridPosition.Y >= 0 && gridPosition.Y < GridHeight);
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