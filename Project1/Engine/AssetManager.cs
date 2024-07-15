using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Project1.Engine
{

    internal class AssetManager
    {
        #region Member Variables
        ContentManager contentManager;
        #endregion
        #region Properties
        #endregion
        #region Constructor
        /// <summary>
        /// Creates a AssetManager object
        /// </summary>
        /// <param name="contentManager"></param>
        public AssetManager(ContentManager contentManager)
        {
            this.contentManager = contentManager;
        }
        #endregion
        #region Public Methods
        public Texture2D LoadSprite(string spriteFileName)
        {
            return contentManager.Load<Texture2D>(spriteFileName);
        }
        #endregion
        #region Private Methods
        #endregion
    }
}
