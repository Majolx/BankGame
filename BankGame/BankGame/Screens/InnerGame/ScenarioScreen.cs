#region Using Statements
using System.IO;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BankGame.Map;
using Microsoft.Xna.Framework.Content;
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
        public GameMap map;

        // Declare globals
        public static Vector2 drawOffset = Vector2.Zero;


        // Declare textures
        public static Texture2D tileSheet;
        private Texture2D[] tileTextures;
        private Texture2D[] characterTextures;

        // Declare file name
        private string levelFileName = "level.txt";

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
            
            // Load the tile sheet
            tileSheet = content.Load<Texture2D>("res/img/map/tileSet");

            // Set up the list of tiles we will use to make the map.
            setupTiles();

            // Build the map
            map.LoadMap(levelFileName);

            // Load the tile set bounds
            map.LoadTileSet(tileSheet);
        }


        private void setupTiles()
        {
            // First load all texture content
            tileTextures = new Texture2D[5];
            tileTextures[0] = content.Load<Texture2D>("res/img/map/tempTile01");
            tileTextures[1] = content.Load<Texture2D>("res/img/map/tempTile02");
            tileTextures[2] = content.Load<Texture2D>("res/img/map/tempTile03");
            tileTextures[3] = content.Load<Texture2D>("res/img/map/tempTile04");
            tileTextures[4] = content.Load<Texture2D>("res/img/map/tempTile05");

            // Add the tile types to the tile list.
            for (int i = 0; i < 5; i++)
            {
                map.Tiles.Add(new Tile(tileTextures[i], false, false));
            }
        }


        /// <summary>
        /// Take a given character and return the tile type it represents
        /// within the tile toolbox.
        /// </summary>
        private Tile readTile(char c)
        {
            Tile tile;

            switch (c)
            {
                case '0':
                    tile = new Tile(map.Tiles[0]);
                    break;
                case '1':
                    tile = new Tile(map.Tiles[1]);
                    break;
                case '2':
                    tile = new Tile(map.Tiles[2]);
                    break;
                default:
                    tile = new Tile(map.Tiles[3]);
                    break;
            }

            return tile;
        }


        #endregion

        #region Update and Draw


        public override void HandleInput(InputState input)
        {

        }


        public override void Draw(GameTime gameTime)
        {
            // Load up the utility sprite batch from ScreenManager
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;

            spriteBatch.Begin();

            // Draw the map
            map.DrawMap(spriteBatch);

            spriteBatch.End();
        }


        #endregion
    }
}
