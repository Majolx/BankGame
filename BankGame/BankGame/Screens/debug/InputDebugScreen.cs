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
        string mouseButtonMessage = "";
        string mouseCoordMessage = "";

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;
            SpriteFont font = ScreenManager.Font;

            spriteBatch.Begin();
            spriteBatch.DrawString(font, mouseButtonMessage, new Vector2(0, 0), Color.White);
            spriteBatch.DrawString(font, mouseCoordMessage, new Vector2(0, 30), Color.White);
            spriteBatch.End();
        }

        public override void HandleInput(InputState input)
        {
            // Display the mouse button states
            mouseButtonMessage = "";
            if (input.mouseIsDown(MouseButton.Left))
            {
                mouseButtonMessage += " Mouse Down(Left) ";
            }
            if (input.mouseIsUp(MouseButton.Left))
            {
                mouseButtonMessage += " Mouse Up(Left) ";
            } 

            if (input.mouseIsDown(MouseButton.Right))
            {
                mouseButtonMessage += " Mouse Down(Right) ";
            }
            if (input.mouseIsUp(MouseButton.Right))
            {
                mouseButtonMessage += " Mouse Up(Right) ";
            }

            if (input.mouseIsDown(MouseButton.Middle))
            {
                mouseButtonMessage += " Mouse Down(Middle) ";
            }
            if (input.mouseIsUp(MouseButton.Middle))
            {
                mouseButtonMessage += " Mouse Up(Middle) ";
            }

            // Display the mouse coordinates
            mouseCoordMessage = "X: " + input.MouseX() + " Y: " + input.MouseY();
        }
    }
}
