#region Using Statements
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
#endregion


namespace BankGame.Map
{
    /// <summary>
    /// A helper class for managing map elements.  It acts as a grid that
    /// tiles align to, to create the background elements.  It is used
    /// by the map objects to ensure proper snap placement in the map.
    /// </summary>
    class MapLayout
    {
        #region Properties


        /// <summary>
        /// The width of the map in pixels.
        /// </summary>
        public int Width
        {
            get { return width; }
        }
        private int width;


        /// <summary>
        /// The height of the map in pixels.
        /// </summary>
        public int Height
        {
            get { return height; }
        }
        private int height;


        /// <summary>
        /// The width of the map in tiles.
        /// </summary>
        public int NumberOfTilesX
        {
            get { return numberOfTilesX; }
            set { numberOfTilesX = value; }
        }
        private int numberOfTilesX;


        /// <summary>
        /// The height of the map in tiles.
        /// </summary>
        public int NumberOfTilesY
        {
            get { return numberOfTilesY; }
            set { numberOfTilesY = value; }
        }
        private int numberOfTilesY;


        /// <summary>
        /// The size of the tiles in pixels.  Since the tiles are perfect
        /// squares, only one value is needed to represent both width
        /// and height.
        /// </summary>
        public int TileSize
        {
            get { return tileSize; }
            set { tileSize = value; }
        }
        private int tileSize;


        #endregion

        #region Initialization


        /// <summary>
        /// Constructor.
        /// </summary>
        public MapLayout()
        {

        }

        #endregion
    }
}
