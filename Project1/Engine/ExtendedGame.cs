using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
namespace Project1.Engine
{
    internal class ExtendedGame : Game
    {
        #region Member Variables
        // Standard Monogame objects for graphics and sprites
        protected GraphicsDeviceManager graphics;
        protected SpriteBatch spriteBatch;
        // Object for handling keyboard and mouse input
        protected InputHelper inputHelper;
        // The game world size
        protected Point worldSize;
        // The game window size
        protected Point windowSize;
        // Matrix used for scaling the game world so it fits inside the window
        Matrix spriteScaleMatrix;
        // Default Values
        const int DEFAULT_WINDOW_SIZE_X = 1024;
        const int DEFAULT_WINDOW_SIZE_Y = 768;
        const int DEFAULT_GAMEWORLD_SIZE_X = 1024;
        const int DEFAULT_GAMEWORLD_SIZE_Y = 768;
        #endregion
        #region Properties
        /// <summary>
        /// An object to return a RandomNumber
        /// </summary>
        public static Random RandomNumberGenerator
        {
            get;
            private set;
        }
        /// <summary>
        /// An object for loading assets in the game
        /// </summary>
        public static AssetManager AssetManager
        {
            get;
            private set;
        }
        /// <summary>
        /// An object that manages all the game states
        /// </summary>
        public static GameStateManager GameStateManager
        {
            get;
            private set;
        }
        public bool IsFullScreen
        {
            get
            {
                return graphics.IsFullScreen;
            }
            protected set
            {
                ApplyScreenResolutionSettings(value);
            }
        }
        #endregion
        #region Constructor 
        /// <summary>
        /// Creates a new ExtendedGame Object
        /// </summary>
        protected ExtendedGame()
        {
            Content.RootDirectory = "Content";
            graphics = new GraphicsDeviceManager(this);
            // Create the inputHelper and RandomNumberGenerator
            inputHelper = new InputHelper();
            RandomNumberGenerator = new Random();
            // Set default for window and world size
            windowSize = new Point(DEFAULT_WINDOW_SIZE_X, DEFAULT_WINDOW_SIZE_Y);
            worldSize = new Point(DEFAULT_GAMEWORLD_SIZE_X, DEFAULT_GAMEWORLD_SIZE_Y);
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Does the initalization takes to load assets and create the game world. Override this method to change specific things when the game start   
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // Initialize the asset manager
            AssetManager = new AssetManager(Content);
            // Create an empty game world
            GameStateManager = new GameStateManager();
            // Set Fullscreen to false by default
            IsFullScreen = false;
            Window.Title = "Penguin Pairs";
        }
        /// <summary>
        /// Updates all the objects in the game world. HandlesInput from player and then updates
        /// </summary>
        /// <param name="gameTime"> An object containing information about the time that has passed</param>
        protected override void Update(GameTime gameTime)
        {
            HandleInput();
            GameStateManager.Update(gameTime);
        }
        /// <summary>
        /// Performs basic input handling and then calls GameStateManager.HandleInput() for the game world
        /// </summary>
        protected void HandleInput()
        {
            inputHelper.Update();
            // Quit the game if player presses ESC
            if (inputHelper.IsKeyPressed(Keys.Escape))
            {
                Exit();
            }
            // Toggle full-screen mode if the player presses F5
            if (inputHelper.IsKeyPressed(Keys.F5))
            {
                IsFullScreen = !IsFullScreen;
            }
            GameStateManager.HandleInput(inputHelper);
        }
        /// <summary>
        /// Draws the game world
        /// </summary>
        /// <param name="gameTime">An object containing information about the time that has passed</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, spriteScaleMatrix);
            GameStateManager.Draw(gameTime, spriteBatch);
            spriteBatch.End();
        }
        /// <summary>
        /// Scales the window to the desired size, and calculates how the game world should be scale to fit inside the window
        /// </summary>
        /// <param name="isFullScreen">A bool to check if the window should be fullscreen or not</param>
        void ApplyScreenResolutionSettings(bool isFullScreen)
        {
            // Apply the passed in fullscreen settings
            graphics.IsFullScreen = isFullScreen;
            // Get the size of the screen to use
            Point screenSize;
            if (isFullScreen)
            {
                screenSize = new Point(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height);
            }
            else
            {
                screenSize = windowSize;
            }
            // Scale the window to the desired size
            graphics.PreferredBackBufferWidth = screenSize.X;
            graphics.PreferredBackBufferHeight = screenSize.Y;
            graphics.ApplyChanges();
            // Calulate and set the viewport to use
            GraphicsDevice.Viewport = CalculateViewport(screenSize);
            // Calculate how the graphics should be scaled, so that the game world fits inside the window
            spriteScaleMatrix = Matrix.CreateScale((float)GraphicsDevice.Viewport.Width / worldSize.X, (float)GraphicsDevice.Viewport.Height / worldSize.Y, 1);
        }
        /// <summary>
        /// Calculates and returns the viewport to use, the game world fits on the screen while preserving its aspect ration
        /// </summary>
        /// <param name="windowSize">The size of the screen on which the game world will be drawn</param>
        /// <returns>A viewport object that will show the game world as larges as possible while preserving the aspect ratio</returns>
        Viewport CalculateViewport(Point windowSize)
        {
            // Create a viewport to be returned
            Viewport viewport = new Viewport();
            // Calculate the aspect ratios
            float gameAspectRatio = (float)worldSize.X / (float)worldSize.Y;
            float windowAspectRatio = (float)windowSize.X / (float)worldSize.Y;
            // If the widow is wide use the full window height
            if (windowAspectRatio > gameAspectRatio)
            {
                viewport.Width = (int)(windowSize.Y * gameAspectRatio);
                viewport.Height = windowSize.Y;
            }
            else
            {
                viewport.Width = windowSize.X;
                viewport.Height = (int)(windowSize.X / gameAspectRatio);
            }
            // calculate and store the top left corner of the viewport
            viewport.X = (windowSize.X - viewport.Width) / 2;
            viewport.Y = (windowSize.Y - viewport.Height) / 2;
            return viewport;
        }
        /// <summary>
        /// Converts a position in the screen coordinates to a position in world coordinates
        /// </summary>
        /// <param name="screenPosition">A  position in screen coordinates </param>
        /// <returns>he corresponding position in gameworld coordinates.</returns>
        public Vector2 ScreenToWorld(Vector2 screenPosition)
        {
            Vector2 viewportTopLeft = new Vector2(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y);
            float screenToWorldScale = (float)worldSize.X / (float)GraphicsDevice.Viewport.Width;
            return (screenPosition - viewportTopLeft) * screenToWorldScale;
        }


        #endregion
        #region Private Methods
        #endregion
    }
}
