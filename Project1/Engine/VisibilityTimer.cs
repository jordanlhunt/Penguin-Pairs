using Microsoft.Xna.Framework;

namespace Project1.Engine
{
    /// <summary>
    /// An object taht can make another object visible for a certain amount of time
    /// </summary>
    internal class VisibilityTimer : GameObject
    {
        #region Member Variables
        GameObject targetGameObject;
        float timeRemaining;
        #endregion
        #region Properties
        #endregion
        #region Constructor
        /// <summary>
        /// Creates a new VisibilityTimer with the given target object
        /// </summary>
        /// <param name="target">The game object whose visiblity you want to manage</param>
        public VisibilityTimer(GameObject target)
        {
            timeRemaining = 0;
            targetGameObject = target;
        }
        #endregion
        #region Public Methods
        public override void Update(GameTime gameTime)
        {
            // if the timer has already passed don't do anything
            if (timeRemaining <= 0)
            {
                return;
            }
            // Decrease the timer by the the time that has passed since the last frame
            timeRemaining -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            // if enough time has passed make the target object invisible
            if (timeRemaining <= 0)
            {
                targetGameObject.IsVisible = false;
            }
        }
        public void StartVisible(float visibleDuration)
        {
            timeRemaining = visibleDuration;
            targetGameObject.IsVisible = true;
        }
        #endregion
        #region Private Methods
        #endregion
    }
}
