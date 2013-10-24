#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BankGame.Map;
using Microsoft.Xna.Framework.Content;
#endregion

namespace BankGame.Screens
{
    class ScenarioScreen : GameScreen
    {
        #region Fields

        ContentManager content;
        GameMap gameMap;
        Texture2D tex1;
        Texture2D tex2;
        Texture2D tex3;
        Texture2D tex4;
        Texture2D tex5;

        #endregion

        #region Properties

        #endregion

        #region Initialize


        public ScenarioScreen()
        {
            gameMap = new GameMap();
            // Temporary code for initializing the tile map
            setupTileMap();
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
        }

        private void setupTileMap()
        {
            Tile.TileSize = 64;
            gameMap.Tiles.Add(new Tile(tex1, false, false));
            gameMap.Tiles.Add(new Tile(tex2, false, false));
            gameMap.Tiles.Add(new Tile(tex3, false, false));
            gameMap.Tiles.Add(new Tile(tex4, false, false));
            gameMap.Tiles.Add(new Tile(tex5, false, false));

            gameMap.NumberOfTilesX = 7;
            gameMap.NumberOfTilesY = 7;

            int c = 0;
            for (int i = 0; i < gameMap.NumberOfTilesY; i++)
            {
                for (int j = 0; j < gameMap.NumberOfTilesX; j++)
                {
                    gameMap.TileMap.Add(gameMap.Tiles[c]);
                    if (c > 4) c = 0;
                }

            }
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
            Rectangle tileArea;
            foreach (Tile tile in gameMap.TileMap)
            {
                if (tileCountX > gameMap.NumberOfTilesX)
                {
                    tileCountX = 0;
                    tileCountY++;
                }


                tileArea = new Rectangle(size * tileCountX,
                                         size * tileCountY,
                                         size * (tileCountX + 1),
                                         size * (tileCountY + 1));

                spriteBatch.Draw(tile.Texture, tileArea, Color.White);
            }

            spriteBatch.End();
        }


        #endregion
    }
}
