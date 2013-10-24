#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BankGame.Map;
#endregion

namespace BankGame.Screens
{
    class ScenarioScreen : GameScreen
    {
        #region Fields

        GameMap gameMap;

        #endregion

        #region Properties

        #endregion

        #region Initialize

        #endregion

        #region Update and Draw


        public void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;
            Rectangle levelSize = new Rectangle(0, 0, gameMap.Width, gameMap.Height);

            spriteBatch.Begin();

            gameMap.Draw(spriteBatch);

            spriteBatch.End();
        }
        #endregion
    }
}
