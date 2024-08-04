using Microsoft.Xna.Framework;
using Project1.Engine;
using Project1.GameStates;
using System;

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
            // Add The Game State
            AddGameStates(GameStateManager);
            GameStateManager.SwitchGameState(STATENAME_TITLE);
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
