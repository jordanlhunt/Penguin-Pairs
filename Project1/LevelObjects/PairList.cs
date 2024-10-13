using Microsoft.Xna.Framework;
using Project1.Engine;

namespace Project1.LevelObjects
{
    internal class PairList : GameObjectList
    {
        #region Member Variables
        int numberOfPairsMade;
        SpriteGameObject[] pairObjects;
        #endregion
        #region Properties
        public bool IsCompleted
        {
            get
            {
                return numberOfPairsMade == pairObjects.Length;
            }
        }
        #endregion
        #region Constructor
        public PairList(int numberOfPairs)
        {
            // Add the background image
            AddChild(new SpriteGameObject("Sprites/spr_frame_goal"));
            // Add a sprite object for each pair that the player should make
            Vector2 spriteOffset = new Vector2(100, 7);
            pairObjects = new SpriteGameObject[numberOfPairs];
            for (int i = 0; i < numberOfPairs; i++)
            {
                pairObjects[i] = new SpriteGameObject("Sprites/spr_penguin_pairs@8", 7);
                pairObjects[i].LocalPosition = spriteOffset + new Vector2(i * pairObjects[i].Width, 0);
                AddChild(pairObjects[i]);
            }
            // Start the number of pairs at 0
            this.numberOfPairsMade = 0;
        }
        #endregion
        #region Public Methods
        public void AddPair(int penguinIndex)
        {
            pairObjects[numberOfPairsMade].SheetIndex = penguinIndex;
            numberOfPairsMade++;
        }
        #endregion
    }
}
