using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BankGame.Screens
{
    class NewGameMenuScreen : GameScreen
    {
        string tempMessage = "New Game Menu Screen";

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;
            SpriteFont font = ScreenManager.Font;

            // Draw a message saying what screen we are in
            spriteBatch.Begin();
            spriteBatch.DrawString(font, tempMessage, new Vector2(0, 0), Color.White);
            spriteBatch.End();
        }
    }
}
