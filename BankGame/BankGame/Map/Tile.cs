#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace BankGame.Map
{
    class Tile
    {
        #region Properties


        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        private Texture2D texture;
        

        public double TileSize
        {
            get { return tileSize; }
            set { tileSize = value; }
        }

        private double tileSize; // The size of the tile


        public bool IsDestructable
        {
            get { return isDestructable; }
            set { isDestructable = value; }
        }

        private bool isDestructable;


        public bool IsDestroyed
        {
            get { return isDestroyed; }
            set { isDestroyed = value; }
        }

        private bool isDestroyed;


        public bool IsCollidable
        {
            get { return isCollidable; }
            set { isCollidable = value; }
        }

        private bool isCollidable;


        public bool ContainsObject
        {
            get { return containsObject; }
            set { containsObject = value; }
        }

        private bool containsObject;

        #endregion

        #region Initialization

        public Tile(Texture2D texture, double tileSize, bool isDestructable, bool isCollidable, bool containsObject)
        {
            this.texture = texture;
            this.tileSize = tileSize;
            this.isDestructable = isDestructable;
            this.isCollidable = isCollidable;
            this.containsObject = containsObject;
        }

        #endregion
    }
}
