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
        #region Properties


        /// <summary>
        /// The width of the map.
        /// </summary>
        public int Width
        {
            get { return width; }
        }
        private int width;


        /// <summary>
        /// The height of the map.
        /// </summary>
        public int Height 
        { 
            get { return height; }
        }
        private int height;


        public int NumberOfTilesX;
        public int NumberOfTilesY;

        /// <summary>
        /// A list of tiles to be used by the tile map.
        /// </summary>
        public List<Tile> Tiles
        {
            get { return tiles; }
        }

        private List<Tile> tiles;


        /// <summary>
        /// The collection of tiles placed on the map. The array works as a coordinate
        /// system, so the first bracket represents the X coordinate and the second
        /// bracket represents the Y coordinate.
        /// </summary>
        public List<Tile> TileMap
        {
            get { return tileMap; }
        }

        private List<Tile> tileMap;


        #endregion

        #region Initialization


        /// <summary>
        /// Constructor.
        /// </summary>
        public GameMap()
        {
            this.tiles = new List<Tile>();
            this.tileMap = new List<Tile>();
        }

        #endregion

        #region Update

        #endregion
    }
}
