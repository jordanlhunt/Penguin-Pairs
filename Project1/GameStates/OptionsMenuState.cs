﻿using Project1.Engine;
using Project1.Engine.UserInterface;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace Project1.GameStates
{
    internal class OptionsMenuState : GameState
    {
        #region Member Variables
        Button backButton;
        #endregion
        #region Properties
        #endregion
        #region Constructor
        public OptionsMenuState()
        {
            SpriteGameObject optionMenuStateSprite = new SpriteGameObject("Sprites/spr_background_options");
            // gameObjectsList is a protected variable, so subclasses of GameState can access it. 
            gameObjectsList.AddChild(optionMenuStateSprite);
            backButton = new Button("Sprites/UI/spr_button_back");
            backButton.LocalPosition = new Vector2(415, 720);
            gameObjectsList.AddChild(backButton);
        }
        #endregion
        #region Public Methods
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (backButton.IsPressed)
            {
                ExtendedGame.GameStateManager.SwitchGameState(PenguinPairs.STATENAME_TITLE);
            }
        }
        #endregion
        #region Private Methods
        #endregion
    }
}
