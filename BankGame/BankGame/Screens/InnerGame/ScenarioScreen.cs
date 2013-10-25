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
        private GameMap gameMap;
        private Texture2D tex1;
        private Texture2D tex2;
        private Texture2D tex3;
        private Texture2D tex4;
        private Texture2D tex5;

        private string levelFilePath = "level.txt";

        #endregion

        #region Properties

        #endregion

        #region Initialize


        public ScenarioScreen()
        {
            gameMap = new GameMap();

            //setupTileMap();
        }


        public override void LoadContent()
        {
            if (content == null) 
                content = new ContentManager(ScreenManager.Game.Services, "Content");

            tex1 = content.Load<Texture2D>("res/img/map/tempTile01");
            tex2 = content.Load<Texture2D>("res/img/map/tempTile02");
            tex3 = content.Load<Texture2D>("res/img/map/tempTile03");
            tex4 = content.Load<Texture2D>("res/img/map/tempTile04");
            tex5 = content.Load<Texture2D>("res/img/map/tempTile05");

            setupTileMap();
        }


        private void setupTileMap()
        {
            // Set the size of the tiles
            Tile.TileSize = 64;

            // Add the tile types to the tile list.
            // This is like a toolbox of tiles for us to make maps with.
            gameMap.Tiles.Add(new Tile(tex1, false, false));
            gameMap.Tiles.Add(new Tile(tex2, false, true));
            gameMap.Tiles.Add(new Tile(tex3, false, false));
            gameMap.Tiles.Add(new Tile(tex4, false, false));
            gameMap.Tiles.Add(new Tile(tex5, false, false));

            // Set the amount of tiles left/right and up/down
            gameMap.NumberOfTilesX = 12;
            gameMap.NumberOfTilesY = 7;

            // Load the data from the level file into a string
            string levelData = File.ReadAllText(levelFilePath);

            // Add the tiles to the tile map
            int c = 0;
            for (int i = 0; i < gameMap.NumberOfTilesY; i++)
            {
                for (int j = 0; j < gameMap.NumberOfTilesX; j++)
                {
                    // Make sure we ignore newlines
                    if (levelData[c] == '\r')
                        c += 2;

                    Tile tile = readTile(levelData[c]);
                    gameMap.TileMap.Add(tile);
                    c++;
                }

            }
        }


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


        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;
            Rectangle levelSize = new Rectangle(0, 0, gameMap.Width, gameMap.Height);

            spriteBatch.Begin();

            // Draw the map
            int tileCountX = 0;
            int tileCountY = 0;
            int size = Tile.TileSize;
            foreach (Tile tile in gameMap.TileMap)
            {
                if (tileCountX >= gameMap.NumberOfTilesX)
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
