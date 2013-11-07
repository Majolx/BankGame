using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BankGame.Screens
{
    class InputDebugScreen : GameScreen
    {
        string mouseInputMessage = "";

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;
            SpriteFont font = ScreenManager.Font;

            spriteBatch.Begin();
            spriteBatch.DrawString(font, mouseInputMessage, new Vector2(0, 0), Color.White);
            spriteBatch.End();
        }

        public override void HandleInput(InputState input)
        {
            mouseInputMessage = "";
            if (input.mouseIsDown(MouseButton.Left))
            {
                mouseInputMessage += " Mouse Down(Left) ";
            }
            if (input.mouseIsUp(MouseButton.Left))
            {
                mouseInputMessage += " Mouse Up(Left) ";
            } 

            if (input.mouseIsDown(MouseButton.Right))
            {
                mouseInputMessage += " Mouse Down(Right) ";
            }
            if (input.mouseIsUp(MouseButton.Right))
            {
                mouseInputMessage += " Mouse Up(Right) ";
            }

            if (input.mouseIsDown(MouseButton.Middle))
            {
                mouseInputMessage += " Mouse Down(Middle) ";
            }
            if (input.mouseIsUp(MouseButton.Middle))
            {
                mouseInputMessage += " Mouse Up(Middle) ";
            }
        }
    }
}
