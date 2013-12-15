#region Using Statements
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System;
#endregion

namespace BankGame.Screens
{
    class MainMenuScreen : MenuScreen
    {
        #region Fields

        Texture2D t2dBackground;
        Texture2D t2dCharacter;
        MobileSprite myCharacter;

        ContentManager content;

        Vector2 scale = new Vector2(3.0f, 3.0f);

        List<Rectangle> bounds = new List<Rectangle>();
        Vector2 p1;
        Vector2 p4;
        float[] x = new float[4];
        float[] y = new float[3];
        float[] m = new float[2];
        float[] triangY = new float[2];
        float rise1;
        float run1;


        #endregion

        #region Initialization


        /// <summary>
        /// Constructor fills in the menu contents.
        /// </summary>
        public MainMenuScreen()
            : base("Heisty")
        {
            // Create our menu entries
            MenuEntry newGameMenuEntry = new MenuEntry("New Game");
            MenuEntry continueMenuEntry = new MenuEntry("Continue");
            MenuEntry tutorialMenuEntry = new MenuEntry("Tutorial");
            MenuEntry optionsMenuEntry = new MenuEntry("Options");
            MenuEntry exitGameMenuEntry = new MenuEntry("Exit Game");
            MenuEntry debugMenuEntry = new MenuEntry("Debug");

            // Hook up menu event handlers
            newGameMenuEntry.Selected += NewGameMenuEntrySelected;
            continueMenuEntry.Selected += ContinueMenuEntrySelected;
            tutorialMenuEntry.Selected += TutorialMenuEntrySelected;
            optionsMenuEntry.Selected += OptionsMenuEntrySelected;
            exitGameMenuEntry.Selected += ExitGameMenuEntrySelected;
            debugMenuEntry.Selected += DebugMenuEntrySelected;

            // Add entries to the menu
            MenuEntries.Add(newGameMenuEntry);
            MenuEntries.Add(continueMenuEntry);
            MenuEntries.Add(tutorialMenuEntry);
            MenuEntries.Add(optionsMenuEntry);
            MenuEntries.Add(exitGameMenuEntry);
            MenuEntries.Add(debugMenuEntry);

            
        }

        public void InitializeSprite()
        {
            myCharacter = new MobileSprite(t2dCharacter);
            myCharacter.Sprite.AddAnimation("downstop", 0, 0, 32, 32, 1, 0.1f);
            myCharacter.Sprite.AddAnimation("down", 32, 0, 32, 32, 2, 0.1f);
            myCharacter.Sprite.AddAnimation("rightstop", 32 * 3, 0, 32, 32, 1, 0.1f);
            myCharacter.Sprite.AddAnimation("right", 32 * 3, 0, 32, 32, 2, 0.1f);
            myCharacter.Sprite.AddAnimation("upstop", 32 * 5, 0, 32, 32, 1, 0.1f);
            myCharacter.Sprite.AddAnimation("up", 32 * 6, 0, 32, 32, 2, 0.1f);
            myCharacter.Sprite.AddAnimation("leftstop", 32 * 8, 0, 32, 32, 1, 0.1f);
            myCharacter.Sprite.AddAnimation("left", 32 * 8, 0, 32, 32, 2, 0.1f);
            myCharacter.Sprite.CurrentAnimation = "downstop";
            myCharacter.Sprite.AutoRotate = false;
            myCharacter.IsPathing = false;
            myCharacter.IsMoving = false;

            // Position the character to be directly in the middle of the table
            Viewport vp = ScreenManager.Game.GraphicsDevice.Viewport;
            Texture2D tex = myCharacter.Sprite.Texture;
            int posX = (vp.Width / 2) - (tex.Width / 30);
            int posY = (vp.Height / 3) * 2;
            myCharacter.Position = new Vector2(posX, posY);
        }

        public override void LoadContent()
        {
            // Make sure the screen-specific content manager exists
            if (content == null) 
                content = new ContentManager(ScreenManager.Game.Services, "Content");

            t2dBackground = content.Load<Texture2D>("res/img/bgr/mafia");
            t2dCharacter = content.Load<Texture2D>("res/img/spr/ThiefSpriteSheet");

            InitializeSprite();

            // Create collision bounds
            float scaleX = (float)ScreenManager.Game.GraphicsDevice.Viewport.Width / (float)t2dBackground.Width;
            float scaleY = (float)ScreenManager.Game.GraphicsDevice.Viewport.Height / (float)t2dBackground.Height;

            x[0] = 512 * scaleX;
            x[1] = 768 * scaleX;
            x[2] = 1488 * scaleX;
            x[3] = 1728 * scaleX;

            y[0] = 1008 * scaleY;
            y[1] = 1471 * scaleY;
            y[2] = 1632 * scaleY;


            p1 = new Vector2(x[0], y[0]);
            Vector2 p2 = new Vector2(x[1], y[0]);
            Vector2 p3 = new Vector2(x[0], y[1]);

            p4 = new Vector2(x[2], y[0]);
            Vector2 p5 = new Vector2(x[3], y[0]);
            Vector2 p6 = new Vector2(x[3], y[1]);


            // Slope formula
            rise1 = p3.Y - p1.Y;
            run1 = p2.X - p1.X;
            m[0] = rise1 / run1;

            float rise2 = p4.Y - p6.Y;
            float run2 = p5.X - p4.X;
            m[1] = rise2 / run2;


            

            base.LoadContent();
        }

        #endregion

        #region Handle Input


        /// <summary>
        /// Event handler for when the New Game menu entry is selected.
        /// </summary>
        void NewGameMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new NewGameMenuScreen(), e.PlayerIndex);
        }


        /// <summary>
        /// Event handler for when the Continue menu entry is selected.
        /// </summary>
        void ContinueMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new ContinueMenuScreen(), e.PlayerIndex);
        }

        
        /// <summary>
        /// Event handler for when the Tutorial menu entry is selected.
        /// </summary>
        void TutorialMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new TutorialScreen(), e.PlayerIndex);
        }

        /// <summary>
        /// Event hander for when the Options menu entry is selected.
        /// </summary>
        void OptionsMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new OptionsScreen(), e.PlayerIndex);
        }

        /// <summary>
        /// Event handler for when the Exit Game menu entry is selected.
        /// </summary>
        void ExitGameMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            // Exit game code
        }


        void DebugMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new DebugMenuScreen(), e.PlayerIndex);
        }

        #endregion

        #region Update & Draw


        public override void HandleInput(InputState input)
        {
            KeyboardState ks = input.CurrentKeyboardStates[0];

            // Character movement keys
            bool wKey = ks.IsKeyDown(Keys.W);
            bool aKey = ks.IsKeyDown(Keys.A);
            bool sKey = ks.IsKeyDown(Keys.S);
            bool dKey = ks.IsKeyDown(Keys.D);

            /// W ///
            if (wKey)
            {
                if (myCharacter.Sprite.CurrentAnimation != "up" && !aKey && !sKey && !dKey)
                {
                    myCharacter.Sprite.CurrentAnimation = "up";
                }
                if (isColliding())
                {
                    if (myCharacter.Sprite.Y < y[0])
                    {
                        myCharacter.Sprite.CurrentAnimation = "upstop";
                    }
                    else
                    {
                        myCharacter.Sprite.MoveBy(2, -1);
                    }
                }
                else
                myCharacter.Sprite.MoveBy(0, -4);
            }

            /// A ///
            if (aKey)
            {
                if (myCharacter.Sprite.CurrentAnimation != "left" && !sKey && !dKey)
                {
                    myCharacter.Sprite.CurrentAnimation = "left";
                }
                if (isColliding())
                {
                    myCharacter.Sprite.CurrentAnimation = "leftstop";
                }
                else
                {
                    myCharacter.Sprite.MoveBy(-4, 0);
                }
            }

            /// S ///
            if (sKey)
            {
                if (myCharacter.Sprite.CurrentAnimation != "down" && !dKey)
                {
                    myCharacter.Sprite.CurrentAnimation = "down";
                }
                if (isColliding())
                {
                    myCharacter.Sprite.CurrentAnimation = "downstop";
                }
                else
                {
                    myCharacter.Sprite.MoveBy(0, 4);
                }
            }

            /// D ///
            if (dKey)
            {
                if (myCharacter.Sprite.CurrentAnimation != "right")
                {
                    myCharacter.Sprite.CurrentAnimation = "right";
                }
                myCharacter.Sprite.MoveBy(4, 0);
            }

            /// NO MOVEMENT ///
            if (!wKey && !aKey && !sKey && !dKey)
            {
                if (myCharacter.Sprite.CurrentAnimation == "up")
                {
                    myCharacter.Sprite.CurrentAnimation = "upstop";
                }
                if (myCharacter.Sprite.CurrentAnimation == "right")
                {
                    myCharacter.Sprite.CurrentAnimation = "rightstop";
                }
                if (myCharacter.Sprite.CurrentAnimation == "down")
                {
                    myCharacter.Sprite.CurrentAnimation = "downstop";
                }
                if (myCharacter.Sprite.CurrentAnimation == "left")
                {
                    myCharacter.Sprite.CurrentAnimation = "leftstop";
                }
            }

            base.HandleInput(input);
        }


        public bool isColliding()
        {
            float charX = myCharacter.Position.X;
            float charY = myCharacter.Position.Y;

            // Check first triangle collision
            if (charY < triangY[0] && charX < x[1])
                return true;

            // Check second triangle collision
            if (charY < triangY[1] && charX > x[2])
                return true;

            // Check top collision
            if (charY < y[0]) 
                return true;

            // Check bottom collision
            if (charY > ScreenManager.Game.GraphicsDevice.Viewport.Height - myCharacter.Sprite.Height) 
                return true;

            // No collisions detected
            return false;
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            myCharacter.Update(gameTime);

            triangY[0] = -m[0] * (myCharacter.Sprite.Position.X - p1.X) + y[1];
            triangY[1] = m[1] * (myCharacter.Sprite.Position.X - p4.X) + p4.Y;
            
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
        }


        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;
            Viewport vp = ScreenManager.Game.GraphicsDevice.Viewport;


            spriteBatch.Begin();

            spriteBatch.Draw(t2dBackground, new Rectangle(0, 0, vp.Width, vp.Height), Color.White);

            spriteBatch.End();


            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap, DepthStencilState.None, RasterizerState.CullCounterClockwise);

            Vector2 v2LinePosition;

            Texture2D pixel = new Texture2D(ScreenManager.Game.GraphicsDevice, 1, 1);
            Color[] colors = new Color[1];
            colors[0] = Color.Red;
            pixel.SetData(colors);

            for (int i = (int)x[0]; i < (int)x[1]; i++)
            {
                int myY = Convert.ToInt32(-m[0] * (i - p1.X) + y[1]);
                v2LinePosition = new Vector2(i, myY);
                spriteBatch.Draw(pixel, v2LinePosition, Color.White);
            }
            
            myCharacter.Draw(spriteBatch, scale);

            spriteBatch.DrawString(ScreenManager.Font, "f(x) = " + (ScreenManager.Game.GraphicsDevice.Viewport.Height - myCharacter.Sprite.Height), new Vector2(10, 10), Color.White);
            spriteBatch.DrawString(ScreenManager.Font, "X: " + myCharacter.Sprite.X + " Y: " + myCharacter.Sprite.Y, new Vector2(10, 30), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
        #endregion
    }
}
