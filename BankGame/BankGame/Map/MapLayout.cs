#region Using Statements
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
#endregion


// This file currently under constructon. -m

namespace BankGame.Map
{
    class MapLayout
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


        #endregion

        #region Initialization


        /// <summary>
        /// Constructor.
        /// </summary>
        public MapLayout(int numberOfTilesX, int numberOfTilesY)
        {
            this.NumberOfTilesX = numberOfTilesX;
            this.NumberOfTilesY = numberOfTilesY;
        }

        #endregion

        #region Update

        #endregion
    }
}
