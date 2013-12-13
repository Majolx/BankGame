#region Using Statements
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using BankGame.Screens;
#endregion


namespace BankGame.Map
{
    class GameMap
    {
        #region Fields

        Texture2D tileSheet;

        // Declare a list of tile layeres
        List<Layer> layers;

        // Declare a rectangle list to hold the tile bounds
        public List<Rectangle> tileSet = new List<Rectangle>();

        // Declare a rectangle to temporarily hold the tile bounds
        Rectangle bounds;

        #endregion
        
        #region Properties


        // Declare the map and tile dimensions
        public int MapWidth { get; set; }
        public int MapHeight { get; set; }
        public int TileWidth { get; set; }
        public int TileHeight { get; set; }


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
            layers = new List<Layer>();
        }


        public void LoadMap(String fileName)
        {
            try 
            {
                // Declare and initialize the stream reader object
                System.IO.StreamReader objReader = new System.IO.StreamReader(fileName);

                // Find the map height and width from the file
                MapHeight = Convert.ToInt32(objReader.ReadLine());
                MapWidth = Convert.ToInt32(objReader.ReadLine());
                TileHeight = Convert.ToInt32(objReader.ReadLine());
                TileWidth = Convert.ToInt32(objReader.ReadLine());

                // Read the amount of layers
                int layersCount = Convert.ToInt32(objReader.ReadLine());

                // Reinitialize the map layers
                for (int i = 0; i < layersCount; i++)
                {
                    // Get the collidable property from the text file
                    bool isCollidable = Convert.ToBoolean(objReader.ReadLine());

                    // Reinitialize the map layers
                    layers.Add(new Layer(MapWidth, MapHeight, TileWidth, TileHeight, isCollidable));

                    // Load the layers
                    layers[i].LoadLayer(objReader);
                }

                // Close the text file and dispose of the graphics object
                objReader.Close();
                objReader.Dispose();
            }
            catch (Exception e)
            {
                Debug.WriteLine("There was an error loading the map.\n\nError:\n" + e);
            }


        }


        #endregion

        #region Draw
        

        public void DrawMap(SpriteBatch spriteBatch, Vector2 scale)
        {
             try
            {
                // Loop through all tile positions
                for (int x = 0; x < MapHeight; ++x)
                {
                    for (int y = 0; y < MapWidth; ++y)
                    {
                        
                        // Draw each layer
                        foreach (Layer layer in layers)
                        {
                            if (layer.layer[y, x] != 0)
                            {
                                // Get the tile
                                bounds = tileSet[layer.layer[y, x] - 1];

                                // Draw the tile
                                spriteBatch.Draw(tileSheet,                                                         // Texture
                                    new Vector2(((y - ScenarioScreen.drawOffset.X) * TileWidth * (int)scale.X),    // Position
                                              ((x - ScenarioScreen.drawOffset.Y) * (int)scale.Y * TileHeight)), 
                                                                bounds,                                          // Source rectangle
                                                                Color.White,                                    // Color
                                                                0.0f,                                          // Rotation
                                                                Vector2.Zero,                                 // Origin
                                                                scale,                                       // Scale
                                                                SpriteEffects.None,                         // Mirroring Depth
                                                                0.0f);                                     // Depth
                            }
                        }
                        
                    }
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine("Could not draw the map.\n\nError:\n" + e);
            }
        }


        public void LoadTileSet(Texture2D tileSheet)
        {

            // Save the tile sheet
            this.tileSheet = tileSheet;
            
            // Get the tile dimensions
            int numOfTilesX = (int)tileSheet.Width / TileWidth;
            int numOfTilesY = (int)tileSheet.Height / TileHeight;

            // Initialize the tile set list
            tileSet = new List<Rectangle>(numOfTilesX * numOfTilesY);

            // Get the bounds of all tiles in the sheet
            for (int j = 0; j < numOfTilesY; ++j)
            {
                for (int i = 0; i < numOfTilesX; ++i)
                {
                    bounds = new Rectangle(i * TileWidth, j * TileHeight, TileWidth, TileHeight);
                    tileSet.Add(bounds);
                }
            }
        }


        #endregion
    }
}
