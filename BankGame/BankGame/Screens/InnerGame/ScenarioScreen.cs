#region Using Statements
using System.IO;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BankGame.Map;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
#endregion

namespace BankGame.Screens
{
    /// <summary>
    /// The core gameplay screen.
    /// </summary>
    class ScenarioScreen : GameScreen
    {
        #region Fields

        private ContentManager content;

        // Declare game elements
        public GameMap map;
        public Vector2 scale = new Vector2(2.0f, 2.0f);

        // Sprite fields
        Texture2D t2dCharacter;
        MobileSprite myCharacter;

        // Declare globals
        public static Vector2 drawOffset = Vector2.Zero;

        float screenSpeed = 0.1f;

        // Declare file name
        private string levelFileName = "TestMap.txt";

        #endregion

        
        #region Initialize

        /// <summary>
        /// Constructor.
        /// </summary>
        public ScenarioScreen()
        {
            map = new GameMap();
        }

         
        public override void LoadContent()
        {
            // Make sure the screen-specific content manager exists
            if (content == null) 
                content = new ContentManager(ScreenManager.Game.Services, "Content");
            
            // Load the map tile sheet
            Texture2D tileSheet = content.Load<Texture2D>("res/img/map/surooshSheet");

            // Load the character sprite
            t2dCharacter = content.Load<Texture2D>("res/img/spr/ThiefSpriteSheet");

            // Build the map
            map.LoadMap(levelFileName);

            // Load the tile set bounds
            map.LoadTileSet(tileSheet);

            // Initialize the sprite
            Initialize();
        }


        public void Initialize()
        {
            myCharacter = new MobileSprite(t2dCharacter);
            myCharacter.Sprite.AddAnimation("downstop", 0, 0, 32, 32, 1, 0.1f);
            myCharacter.Sprite.AddAnimation("down", 0, 0, 32, 32, 3, 0.1f);
            myCharacter.Sprite.AddAnimation("rightstop", 32 * 3, 0, 32, 32, 1, 0.1f);
            myCharacter.Sprite.AddAnimation("right", 32 * 3, 0, 32, 32, 2, 0.1f);
            myCharacter.Sprite.AddAnimation("upstop", 32 * 5, 0, 32, 32, 1, 0.1f);
            myCharacter.Sprite.AddAnimation("up", 32 * 5, 0, 32, 32, 3, 0.1f);
            myCharacter.Sprite.AddAnimation("leftstop", 32 * 8, 0, 32, 32, 1, 0.1f);
            myCharacter.Sprite.AddAnimation("left", 32 * 8, 0, 32, 32, 2, 0.1f);
            myCharacter.Sprite.CurrentAnimation = "downstop";
            myCharacter.Position = new Vector2(0, 0);
            myCharacter.Sprite.AutoRotate = false;
            myCharacter.IsPathing = false;
            myCharacter.IsMoving = false;
        }

        #endregion

        #region Update and Draw


        public override void HandleInput(InputState input)
        {
            KeyboardState ks = input.CurrentKeyboardStates[0];

            // Character movement keys
            bool wKey = ks.IsKeyDown(Keys.W);
            bool aKey = ks.IsKeyDown(Keys.A);
            bool sKey = ks.IsKeyDown(Keys.S);
            bool dKey = ks.IsKeyDown(Keys.D);

            // Camera movement keys
            bool upKey = ks.IsKeyDown(Keys.Up);
            bool leftKey = ks.IsKeyDown(Keys.Left);
            bool downKey = ks.IsKeyDown(Keys.Down);
            bool rightKey = ks.IsKeyDown(Keys.Right);

            /// W ///
            if (wKey)
            {
                if (myCharacter.Sprite.CurrentAnimation != "up" && !aKey && !sKey && !dKey)
                {
                    myCharacter.Sprite.CurrentAnimation = "up";
                }
                myCharacter.Sprite.MoveBy(0, -2);
            }

            /// A ///
            if (aKey)
            {
                if (myCharacter.Sprite.CurrentAnimation != "left" && !sKey && !dKey)
                {
                    myCharacter.Sprite.CurrentAnimation = "left";
                }
                myCharacter.Sprite.MoveBy(-2, 0);
            }

            /// S ///
            if (sKey)
            {
                if (myCharacter.Sprite.CurrentAnimation != "down" && !dKey)
                {
                    myCharacter.Sprite.CurrentAnimation = "down";
                }
                myCharacter.Sprite.MoveBy(0, 2);
            }

            /// D ///
            if (dKey)
            {
                if (myCharacter.Sprite.CurrentAnimation != "right")
                {
                    myCharacter.Sprite.CurrentAnimation = "right";
                }
                myCharacter.Sprite.MoveBy(2, 0);
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


            /// CAMERA MOVEMENT ///
            /// UP ///
            if (upKey)
            {
                if (drawOffset.Y > -5)
                    drawOffset.Y -= screenSpeed;
            }

            /// LEFT ///
            if (leftKey)
            {
                if (drawOffset.X > -5)
                    drawOffset.X -= screenSpeed;
            }

            /// DOWN ///
            if (downKey)
            {
                if (drawOffset.Y < map.MapHeight - 1)
                    drawOffset.Y += screenSpeed;
            }

            /// RIGHT ///
            if (rightKey)
            {
                if (drawOffset.X < map.MapWidth - 1)
                    drawOffset.X += screenSpeed;
            }
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            myCharacter.Update(gameTime);

            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
        }

        public override void Draw(GameTime gameTime)
        {
            // Load up the utility sprite batch from ScreenManager
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap, DepthStencilState.None, RasterizerState.CullCounterClockwise);

            // Draw the map
            map.DrawMap(spriteBatch, scale);

            // Draw the character
            myCharacter.Draw(spriteBatch, scale);

            spriteBatch.End();
        }


        #endregion
    }
}
