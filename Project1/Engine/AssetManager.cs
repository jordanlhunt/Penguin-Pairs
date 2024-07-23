using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
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
        /// <param name="contentManager">A reference to the Monogame ContentManager</param>
        public AssetManager(ContentManager contentManager)
        {
            this.contentManager = contentManager;
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Loads a sprite and returns the texture2D
        /// </summary>
        /// <param name="spriteFileName">The name of the sprite to load</param>
        /// <returns>A Texture2D object containing the loaded sprite</returns>
        public Texture2D LoadSprite(string spriteFileName)
        {
            return contentManager.Load<Texture2D>(spriteFileName);
        }
        /// <summary>
        /// Loads a font and returns the SpriteFont
        /// </summary>
        /// <param name="fontFileName">The name of the font to load</param>
        /// <returns>The name of the asset to Load</returns>
        public SpriteFont LoadFont(string fontFileName)
        {
            return contentManager.Load<SpriteFont>(fontFileName);
        }
        /// <summary>
        /// Loads and plays the sound effect with the provided name
        /// </summary>
        /// <param name="soundEffectFileName">The name of the SoundEffect to play</param>
        public void PlaySoundEffect(string soundEffectFileName)
        {
            SoundEffect soundEffect = contentManager.Load<SoundEffect>(soundEffectFileName);
            soundEffect.Play();
        }
        /// <summary>
        /// Loads and plays a song with the provided name,
        /// </summary>
        /// <param name="songFileName">The name of the song to play</param>
        /// <param name="isLooping">Checks to see if the song should loop</param>
        public void PlaySong(string songFileName, bool isLooping)
        {
            MediaPlayer.IsRepeating = isLooping;
            MediaPlayer.Play(contentManager.Load<Song>(songFileName));
        }
        #endregion
        #region Private Methods
        #endregion
    }
}
