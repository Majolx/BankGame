using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BankGame
{
    class Sprite
    {
        private Texture2D spriteTexture;
        private List<Rectangle> spriteFrames;
        private int currentFrame;

        public Vector2 Position;

        public Sprite()
        {
            spriteFrames = new List<Rectangle>();
            Position = new Vector2(0, 0);
        }

        /// <summary>
        /// Load sprite function which slices the sprite.
        /// </summary>
        public void Load(ContentManager content, string pathname,
                         int slicesX, int slicesY)
        {
            spriteTexture = content.Load<Texture2D>(pathname);

            {
                // Determine width and height of slice
                int sliceW = spriteTexture.Width / slicesX;
                int sliceH = spriteTexture.Height / slicesY;

                for (int i = 0; i < slicesY; i++)
                {
                    for (int j = 0; j < slicesX; j++)
                    {
                        spriteFrames.Add(new Rectangle(sliceW * j, sliceH * i, sliceW, sliceH));
                    }
                }
            }
        }

        public void setFrame(int frame)
        {
            if (frame > spriteFrames.Count)
            {
                Debug.WriteLine("Frame index out of bounds!");
                return;
            }

            currentFrame = frame;
        }

    }
}
