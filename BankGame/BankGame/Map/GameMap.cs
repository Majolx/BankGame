using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// This file currently under constructon. -m

namespace BankGame.Map
{
    class GameMap
    {
        /// <summary>
        /// A list of tiles to be used by the tile map.
        /// </summary>
        private List<Tile> tiles;


        /// <summary>
        /// The collection of tiles placed on the map.
        /// The array works as a coordinate system, so
        /// the first bracket represents the X coordinate
        /// and the second bracket represents the Y coordinate.
        /// </summary>
        public Tile[][] TileMap
        {
            get { return TileMap; }
        }

        private Tile[][] tileMap;

        private int mapWidth;
        private int mapHeight;


        
        #region Initialization


        /// <summary>
        /// Constructor.
        /// </summary>
        public GameMap(int mapHeight, int mapWidth)
        {
            this.mapHeight = mapHeight;
            this.mapWidth = mapWidth;
        }


        #endregion

        #region Update and Draw



        #endregion
    }
}
