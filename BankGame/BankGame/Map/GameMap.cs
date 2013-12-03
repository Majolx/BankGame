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
        /// A list of tiles to be used by the tile map.  All tiles should be
        /// unique.
        /// </summary>
        public List<Tile> Tiles
        {
            get { return tiles; }
        }

        private List<Tile> tiles;


        /// <summary>
        /// The collection of tiles placed on the map.  This is where the tiles
        /// go in order to be represented in-game.  
        /// </summary>
        public Tile[,] TileMap
        {
            get { return tileMap; }
            set { tileMap = value; }
        }

        private Tile[,] tileMap;


        #endregion

        #region Initialization


        /// <summary>
        /// Constructor.
        /// </summary>
        public GameMap()
        {
            tiles = new List<Tile>();
        }

        #endregion
    }
}
