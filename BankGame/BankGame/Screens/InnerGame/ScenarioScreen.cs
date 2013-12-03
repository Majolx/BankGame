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
        private MapLayout mapLayout;
        private GameMap gameMap;
        private CharacterMap characterMap;
        private Texture2D[] tileTextures;
        private Texture2D[] characterTextures;

        private string levelFilePath = "level.txt";

        private Sprite arrowSprite;

        #endregion

        #region Initialize

        /// <summary>
        /// Constructor.
        /// </summary>
        public ScenarioScreen()
        {
            mapLayout = new MapLayout();
            gameMap = new GameMap();
            arrowSprite = new Sprite();
        }

         
        public override void LoadContent()
        {
            // Make sure the screen-specific content manager exists
            if (content == null) 
                content = new ContentManager(ScreenManager.Game.Services, "Content");
            
            // Set up the toolbox we will use to make the map.
            setupTileToolbox();

            // After setting up the tile toolbox, we can now build a map
            gameMap.TileMap = setupTileMap();

            // Load the arrow sprite
            arrowSprite.Load(content, "res/img/spr/MovementArrow", 15, 1);
        }


        private void setupTileToolbox()
        {
            // First load all texture content
            tileTextures = new Texture2D[5];
            tileTextures[0] = content.Load<Texture2D>("res/img/map/tempTile01");
            tileTextures[1] = content.Load<Texture2D>("res/img/map/tempTile02");
            tileTextures[2] = content.Load<Texture2D>("res/img/map/tempTile03");
            tileTextures[3] = content.Load<Texture2D>("res/img/map/tempTile04");
            tileTextures[4] = content.Load<Texture2D>("res/img/map/tempTile05");

            // Set the size of the tiles
            mapLayout.TileSize = 64;

            // Add the tile types to the tile list.
            for (int i = 0; i < 5; i++)
            {
                gameMap.Tiles.Add(new Tile(tileTextures[i], false, false));
            }
        }


        private Tile[,] setupTileMap()
        {
            /// Read tile map
            string levelData = File.ReadAllText(levelFilePath);


            /// Calculate map width and height
            int x = 0;
            int y = 0;

            foreach (char t in levelData)
            {
                if (t != '\r' && y == 0)    x++;    // Counts the line length
                if (t == '\n')              y++;    // Counts the number of lines
            }
            
            
            mapLayout.NumberOfTilesX = --x;
            mapLayout.NumberOfTilesY = y;

            Tile[,] tileMap = new Tile[mapLayout.NumberOfTilesX,mapLayout.NumberOfTilesY];
            /// Add tiles to tile map
            int c = 0;
            for (int i = 0; i < mapLayout.NumberOfTilesY; i++)
            {
                for (int j = 0; j < mapLayout.NumberOfTilesX; j++)
                {
                    // Make sure we ignore newlines
                    if (levelData[c] == '\r')
                        c += 2;

                    Tile tile = readTile(levelData[c++]);

                    tile.Position = new Vector2(j * mapLayout.TileSize, i * mapLayout.TileSize);

                    // Add the tile to the game map
                    tileMap[j,i] = tile;
                }
            }


            /// DEBUG ///
            Debug.WriteLine(levelData);
            /// DEBUG ///
            

            return tileMap;
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
                    tile = new Tile(gameMap.Tiles[0]);
                    break;
                case '1':
                    tile = new Tile(gameMap.Tiles[1]);
                    break;
                case '2':
                    tile = new Tile(gameMap.Tiles[2]);
                    break;
                default:
                    tile = new Tile(gameMap.Tiles[3]);
                    break;
            }

            return tile;
        }


        #endregion

        #region Update and Draw


        public override void HandleInput(InputState input)
        {
            if (input.mouseWasPressed(MouseButton.Left))
            {
                // Retrieve the mouse position
                Vector2 mousePos = new Vector2(input.MouseX(), input.MouseY());

                // Find the tile that encapsulates this point
                int tileX = (int)(mousePos.X / mapLayout.TileSize);
                int tileY = (int)(mousePos.Y / mapLayout.TileSize);

                // Ensure that we have clicked in the map
                if (tileX < 0 || tileX >= mapLayout.NumberOfTilesX || tileY < 0 || tileY >= mapLayout.NumberOfTilesY)
                {
                    Debug.WriteLine("Click is out of bounds!");
                    return;
                }
                Tile clickedTile = gameMap.TileMap[tileX,tileY];

                Debug.WriteLine(tileX + " " + tileY + " " + clickedTile.Position);
                // Set the arrow sprite to be drawn at this tiles location

                // Check if this tile is different from the last tile
                // Check if arrow has been drawn before
                // Check if new tile is a previous tile
                // Update arrow accordingly
            }
        }


        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;
            Rectangle levelSize = new Rectangle(0, 0, mapLayout.Width, mapLayout.Height);

            spriteBatch.Begin();

            // Draw the map
            for (int i = 0; i < mapLayout.NumberOfTilesY; i++)
            {
                for (int j = 0; j < mapLayout.NumberOfTilesX; j++)
                {
                    Tile tile = gameMap.TileMap[j,i];
                    spriteBatch.Draw(tile.Texture, tile.Position, Color.White);
                }
            }

            // Draw the movement arrow

            spriteBatch.End();
        }


        #endregion
    }
}
