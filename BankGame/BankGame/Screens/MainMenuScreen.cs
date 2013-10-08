#region Using Statements
using Microsoft.Xna.Framework;
#endregion

namespace BankGame.Screens
{
    class MainMenuScreen : MenuScreen
    {
        #region Initialization


        /// <summary>
        /// Constructor fills in the menu contents.
        /// </summary>
        public MainMenuScreen()
            : base("Main Menu")
        {
            // Create our menu entries
            MenuEntry newGameMenuEntry = new MenuEntry("New Game");
            MenuEntry continueMenuEntry = new MenuEntry("Continue");
            MenuEntry tutorialMenuEntry = new MenuEntry("Tutorial");
            MenuEntry optionsMenuEntry = new MenuEntry("Options");
            MenuEntry exitGameMenuEntry = new MenuEntry("Exit Game");
        }


        #endregion

        #region Handle Input


        /// <summary>
        /// Event handler for when the New Game menu entry is selected.
        /// </summary>
        void NewGameMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            LoadingScreen.Load(ScreenManager, true, e.PlayerIndex,
                               new NewGameMenuScreen());
        }


        /// <summary>
        /// Event handler for when the Continue menu entry is selected.
        /// </summary>
        void ContinueMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new ContinueMenuScreen(), e.PlayerIndex);
        }

        
        /// <summary>
        /// Event handler for when the Tutorial menu entry is selected.
        /// </summary>
        void TutorialMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new TutorialScreen(), e.PlayerIndex);
        }


        #endregion
    }
}
