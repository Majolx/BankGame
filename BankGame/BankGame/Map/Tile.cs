#region Using Statements
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
#endregion

namespace BankGame.Map
{
    /// <summary>
    /// The Tile class has values and methods for the tiles
    /// which make up a PlayMap.  It is responsible for tracking
    /// what occupies the tile, its own collision, 
    /// </summary>
    class Tile
    {
        #region Fields

        private Texture2D texture;
        private Vector2 position;
        private static int tileSize;
        private bool isDestructable;
        
        #endregion

        #region Properties


        /// <summary>
        /// The texture of the tile.
        /// </summary>
        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }
        
        /// <summary>
        /// The size of the tile, representing both the height and width.
        /// </summary>
        public static int TileSize
        {
            get { return tileSize; }
            set { tileSize = value; }
        }


        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        /// <summary>
        /// The destructability of the tile.
        /// </summary>
        public bool IsDestructable
        {
            get { return isDestructable; }
            set { isDestructable = value; }
        }


        /// <summary>
        /// True if the tile has been destroyed.
        /// </summary>
        public bool IsDestroyed
        {
            get { return isDestroyed; }
            set { isDestroyed = value; }
        }

        private bool isDestroyed;


        /// <summary>
        /// True if this tile is a collidable tile.
        /// </summary>
        public bool IsCollidable
        {
            get { return isCollidable; }
            set { isCollidable = value; }
        }

        private bool isCollidable;


        /// <summary>
        /// True if the tile has an object within its bounds.
        /// </summary>
        public bool ContainsObject
        {
            get { return containsObject; }
            set { containsObject = value; }
        }

        private bool containsObject;


        #endregion

        #region Initialization


        public Tile()
        {
            this.texture = null;
            this.isDestructable = false;
            this.isCollidable = false;
            this.position = new Vector2();
        }

        public Tile(Tile tile)
        {
            this.texture = tile.Texture;
            this.isDestructable = tile.IsDestructable;
            this.isCollidable = tile.IsCollidable;
            this.position = tile.Position;
        }


        /// <summary>
        /// Constructor for the Tile class.  
        /// </summary>
        public Tile(Texture2D texture, bool isDestructable, 
                    bool isCollidable)
        {
            this.texture        = texture;
            this.isDestructable = isDestructable;
            this.isCollidable   = isCollidable;
            this.position = new Vector2();
        }


        #endregion
    }
}
