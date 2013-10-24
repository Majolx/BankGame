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


        /// <summary>
        /// The X position, in pixels, of the tile.
        /// </summary>
        public int TileX
        {
            get { return tileX; }
            set { tileX = value; }
        }
        private int tileX;

        /// <summary>
        /// The Y position, in pixels, of the tile.
        /// </summary>
        public int TileY
        {
            get { return tileY; }
            set { tileY = value; }
        }

        private int tileY;

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


        /// <summary>
        /// Constructor for the Tile class.  
        /// </summary>
        /// <param name="texture">The texture of the tile.</param>
        /// <param name="tileSize">The size of the tile.</param>
        /// <param name="isDestructable">The destructability of the tile.</param>
        /// <param name="isCollidable">The collidability of the tile.</param>
        /// <param name="containsObject"></param>
        public Tile(Texture2D texture, bool isDestructable, 
                    bool isCollidable)
        {
            this.texture        = texture;
            this.isDestructable = isDestructable;
            this.isCollidable   = isCollidable;
        }


        #endregion

        #region Update and Draw

        /// <summary>
        /// Draws the tile to the screen.
        /// </summary>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Rectangle tileArea = new Rectangle(tileX, tileY,
                                               tileX + tileSize,
                                               tileY + tileSize);

            // Draw the tile
            spriteBatch.Begin();

            spriteBatch.Draw(texture, tileArea, Color.White);

            spriteBatch.End();
        }

        #endregion
    }
}
