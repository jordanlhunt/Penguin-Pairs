using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Project1.Engine
{
    /// <summary>
    /// A class for objects in the game world with a position and velocity
    /// </summary>
    internal class GameObject
    {
        #region Member Variables
        /// <summary>
        /// The current velocity of the game objects
        /// </summary>
        protected Vector2 velocity;
        #endregion
        #region Properties
        /// <summary>
        /// The optional parent of this object in the game-object hierarchy
        /// </summary>
        public GameObject Parent
        {
            get; set;
        }

        /// <summary>
        /// A bool to check if the object is currently visible
        /// </summary>
        public bool IsVisible
        {
            get; set;
        }
        /// <summary>
        /// The position of this game object, relative to its parent in the game-object hierarchy
        /// </summary>
        public Vector2 LocalPosition
        {
            get; set;
        }
        /// <summary>
        /// Gets this object's global position in the game world, by adding its local position to the global position of its parent
        /// </summary>
        public Vector2 GlobalPosition
        {
            get
            {
                if (Parent == null)
                {
                    return LocalPosition;
                }
                else
                {
                    return LocalPosition + Parent.GlobalPosition;
                }
            }
        }

        #endregion
        #region Constructor
        public GameObject()
        {
            LocalPosition = Vector2.Zero;
            velocity = Vector2.Zero;
            IsVisible = true;
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Performs the handling of input of a gameObject, It's virtual so it can been overridden.
        /// </summary>
        /// <param name="inputHelper">An object with information about player input.</param>
        public virtual void HandleInput(InputHelper inputHelper)
        {
        }
        /// <summary>
        /// Draw this GameObject. It's virtual so it can be overridden
        /// </summary>
        /// <param name="gameTime">An object containing information about the time</param>
        /// <param name="spriteBatch">the spriteBatch to use</param>
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
        }
        /// <summary>
        /// Resets the game object to an initial state.
        /// </summary>
        public virtual void Reset()
        {
            velocity = Vector2.Zero;
        }
        #endregion
        #region Private Methods
        #endregion
    }
}
