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
            setupTileMap();

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
            Tile.TileSize = 64;

            // Add the tile types to the tile list.
            for (int i = 0; i < 5; i++)
            {
                gameMap.Tiles.Add(new Tile(tileTextures[i], false, false));
            }
        }


        private void setupTileMap()
        {
            // Set the amount of tiles left/right and up/down
            mapLayout.NumberOfTilesX = 12;
            mapLayout.NumberOfTilesY = 7;

            // Load the data from the level file into a string
            string levelData = File.ReadAllText(levelFilePath);
            

            // Add the tiles to the tile map
            int c = 0;
            for (int i = 0; i < mapLayout.NumberOfTilesY; i++)
            {
                for (int j = 0; j < mapLayout.NumberOfTilesX; j++)
                {
                    // Make sure we ignore newlines
                    if (levelData[c] == '\r')
                        c += 2;

                    // Read the value at this location and
                    // interpret it to tile form
                    Tile tile = readTile(levelData[c]);

                    // Add the tile to the game map
                    gameMap.TileMap.Add(tile);

                    c++;
                }
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
                    tile = gameMap.Tiles[0];
                    break;
                case '1':
                    tile = gameMap.Tiles[1];
                    break;
                case '2':
                    tile = gameMap.Tiles[2];
                    break;
                default:
                    tile = gameMap.Tiles[3];
                    break;
            }

            return tile;
        }


        #endregion

        #region Update and Draw


        public override void HandleInput(InputState input)
        {
            if (input.mouseIsDown(MouseButton.Left))
            {
                
            }
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;
            Rectangle levelSize = new Rectangle(0, 0, mapLayout.Width, mapLayout.Height);

            spriteBatch.Begin();

            // Draw the map
            int tileCountX = 0;
            int tileCountY = 0;
            int size = Tile.TileSize;
            foreach (Tile tile in gameMap.TileMap)
            {
                if (tileCountX >= mapLayout.NumberOfTilesX)
                {
                    tileCountX = 0;
                    tileCountY++;
                }


                int drawPosX = size * tileCountX;
                int drawPosY = size * tileCountY;
                Vector2 drawPos = new Vector2(drawPosX, drawPosY);


                spriteBatch.Draw(tile.Texture, drawPos, Color.White);

                tileCountX++;
            }

            spriteBatch.End();
        }


        #endregion
    }
}
