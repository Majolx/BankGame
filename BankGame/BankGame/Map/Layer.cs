using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace BankGame.Map
{
    public class Layer
    {
        #region Fields


        // Declare map and tile dimensions
        private int mapWidth;
        private int mapHeight;
        private int tileWidth;
        private int tileHeight;

        // Declare collidable property
        public bool IsCollidable
        {
            get { return isCollidable;  }
            set { isCollidable = value; }
        }
        private bool isCollidable;


        #endregion

        // Declare the layer array
        public int[,] layer;


        public Layer(int mapWidth, int mapHeight, int tileWidth, int tileHeight, bool isCollidable)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            this.isCollidable = isCollidable;
            layer = new int[mapWidth, mapHeight];
        }


        public void LoadLayer(System.IO.StreamReader objReader)
        {
            try
            {
                // Populate the layer array
                for (int i = 0; i < mapWidth; ++i)
                {
                    for (int j = 0; j < mapHeight; ++j)
                    {
                        layer[i, j] = Convert.ToInt32(objReader.ReadLine());
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("There was an error loading the layer.\n\nError:\n" + e);
            }
        }
    }
}
