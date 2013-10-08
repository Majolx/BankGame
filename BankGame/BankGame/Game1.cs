#region Using Statements
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
#endregion

namespace BankGame
{
    /// <summary>
    /// Good luck, have fun
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        #region Fields

        // ===== Graphics ============================================//
        GraphicsDeviceManager graphics;

        // ===== Screen State Manager ================================//
        ScreenManager screenManager;

        // ===== Audio Libraries =====================================//
        MediaLibrary bgmLibrary;            // Background Music //
        MediaLibrary sfxLibrary;            //  Sound Effects   //


        // By preloading any assets used by UI rendering, we avoid framerate glitches
        // when they suddenly need to be loaded in the middle of a menu transition.
        static readonly string[] preloadAssets =
        {
            "res/img/gradient",
        };


        #endregion

        #region Initialization


        public Game1()
        {
            Content.RootDirectory = "Content";

            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 720;

            // Create the screen manager component.
            screenManager = new ScreenManager(this);

            Components.Add(screenManager);

            // Activate the first screens.
            // screenManager.AddScreen(new #SCREEN_GOES_HERE#, null);

        }

        /// <summary>
        /// Loads graphics content.
        /// </summary>
        protected override void LoadContent()
        {
            foreach (string asset in preloadAssets)
            {
                Content.Load<object>(asset);
            }
        }


        #endregion

        #region Draw


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Black);

            // The actual drawing happens inside the screen manager component
            base.Draw(gameTime);
        }


        #endregion
    }


    #region Entry Point
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    static class Program
    {
        static void Main(string[] args)
        {
            using (Game1 game = new Game1())
            {
                game.Run();
            }
        }
    }

#endregion
}
