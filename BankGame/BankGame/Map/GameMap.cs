#region Using Statements
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
#endregion


// This file currently under constructon. -m

namespace BankGame.Map
{
    class GameMap
    {
        #region Fields

        #endregion

        #region Properties


        /// <summary>
        /// The width of the map.
        /// </summary>
        public int Width { get; }
        private int width;


        /// <summary>
        /// The height of the map.
        /// </summary>
        public int Height { get; }
        private int height;


        public int NumberOfTilesX;
        public int NumberOfTilesY;

        /// <summary>
        /// A list of tiles to be used by the tile map.
        /// </summary>
        private List<Tile> tiles;


        /// <summary>
        /// The collection of tiles placed on the map. The array works as a coordinate
        /// system, so the first bracket represents the X coordinate and the second
        /// bracket represents the Y coordinate.
        /// </summary>
        public Tile[,] TileMap
        {
            get { return tileMap; }
        }

        private Tile[,] tileMap;


        #endregion

        #region Initialization


        /// <summary>
        /// Constructor.
        /// </summary>
        public GameMap(int height, int width)
        {
            this.height = height;
            this.width  = width;
        }


        #endregion

        #region Update and Draw

        public void Draw(SpriteBatch spriteBatch)
        {
            int counterX = 0;
            int counterY = 0;

            Rectangle tileArea;
            foreach (Tile tile in tileMap[,])
            {
                if (counterX > NumberOfTilesX)
                {
                    counterX = 0;
                    counterY++;
                }
                tileArea = new Rectangle(counterX * tile.TileSize,
                                         counterY * tile.TileSize,
                                         (counterX + 1) * tile.TileSize,
                                         (counterY + 1) * tile.TileSize);

                spriteBatch.Draw(tile.Texture, tileArea, Color.White);
            
            }
            
        }

        #endregion
    }
}
