using Microsoft.Xna.Framework;
using Project1.Engine;
using Project1.GameStates;
using System;
using System.Collections.Generic;
using System.IO;

namespace Project1
{
    class PenguinPairs : ExtendedGame
    {
        #region Member Variables
        public const string STATENAME_TITLE = "title";
        public const string STATENAME_HELP = "help";
        public const string STATENAME_OPTIONS = "options";
        public const string STATENAME_LEVELSELECT = "levelselect";
        public const string STATENAME_PLAYING = "playing";
        static List<LevelStatus> progress;
        #endregion
        #region Properties
        public static bool HintsEnabled
        {
            get;
            set;
        }
        public static int NumberOfLevels
        {
            get
            {
                return progress.Count;
            }

        }
        public static LevelStatus GetLevelStatus(int levelIndex)
        {
            return progress[levelIndex - 1];

        }
        private static void SetLevelStatus(int levelIndex, LevelStatus status)
        {
            progress[levelIndex - 1] = status;
        }
        #endregion
        [STAThread]
        static void Main()
        {
            PenguinPairs game = new PenguinPairs();
            game.Run();
        }

        public PenguinPairs()
        {
            IsMouseVisible = true;
        }
        protected override void LoadContent()
        {
            base.LoadContent();
            // Configure the window
            worldSize = new Point(1200, 900);
            windowSize = new Point(1024, 768);
            IsFullScreen = false;
            LoadProgress();
            // Add The Game States
            AddGameStates(GameStateManager);
            // Have the title screen be the default
            GameStateManager.SwitchGameState(STATENAME_TITLE);
        }

        void LoadProgress()
        {
            progress = new List<LevelStatus>();
            StreamReader streamReader = new StreamReader("Content/Levels/levels_status.txt");
            string line = streamReader.ReadLine();
            while (line != null)
            {
                if (line == "locked")
                {
                    progress.Add(LevelStatus.Locked);
                }
                else if (line == "unlocked")
                {
                    progress.Add(LevelStatus.Unlocked);
                }
                else if (line == "solved")
                {
                    progress.Add(LevelStatus.Solved);
                }
                // go to the next line
                line = streamReader.ReadLine();
            }
        }

        static void SaveProgress()
        {
            StreamWriter streamWriter = new StreamWriter("Content/Levels/levels_status.txt");
            foreach (LevelStatus levelStatus in progress)
            {
                if (levelStatus == LevelStatus.Locked)
                {
                    streamWriter.WriteLine("locked");

                }
                else if (levelStatus == LevelStatus.Unlocked)
                {
                    streamWriter.WriteLine("unlocked");
                }
                else
                {
                    streamWriter.WriteLine("solved");
                }
            }
            streamWriter.Close();
        }

        public static void MarkLevelAsSolved(int levelIndex)
        {
            SetLevelStatus(levelIndex, LevelStatus.Solved);
            if (levelIndex < NumberOfLevels && GetLevelStatus(levelIndex + 1) == LevelStatus.Locked)
            {
                SetLevelStatus(levelIndex + 1, LevelStatus.Unlocked);
            }
            SaveProgress();
        }

        #region Private Helper
        private void AddGameStates(GameStateManager gameStateManager)
        {
            gameStateManager.AddGameState(STATENAME_TITLE, new TitleMenuState());
            gameStateManager.AddGameState(STATENAME_HELP, new HelpMenuState());
            gameStateManager.AddGameState(STATENAME_OPTIONS, new OptionsMenuState());
            gameStateManager.AddGameState(STATENAME_LEVELSELECT, new LevelMenuState());
            gameStateManager.AddGameState(STATENAME_PLAYING, new PlayingState());
        }
        #endregion
    }
}
