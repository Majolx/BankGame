﻿#region Using Statements
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
            MenuEntry debugMenuEntry = new MenuEntry("Debug");

            // Hook up menu event handlers
            newGameMenuEntry.Selected += NewGameMenuEntrySelected;
            continueMenuEntry.Selected += ContinueMenuEntrySelected;
            tutorialMenuEntry.Selected += TutorialMenuEntrySelected;
            optionsMenuEntry.Selected += OptionsMenuEntrySelected;
            exitGameMenuEntry.Selected += ExitGameMenuEntrySelected;
            debugMenuEntry.Selected += DebugMenuEntrySelected;

            // Add entries to the menu
            MenuEntries.Add(newGameMenuEntry);
            MenuEntries.Add(continueMenuEntry);
            MenuEntries.Add(tutorialMenuEntry);
            MenuEntries.Add(optionsMenuEntry);
            MenuEntries.Add(exitGameMenuEntry);
            MenuEntries.Add(debugMenuEntry);
        }


        #endregion

        #region Handle Input


        /// <summary>
        /// Event handler for when the New Game menu entry is selected.
        /// </summary>
        void NewGameMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new NewGameMenuScreen(), e.PlayerIndex);
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

        /// <summary>
        /// Event hander for when the Options menu entry is selected.
        /// </summary>
        void OptionsMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new OptionsScreen(), e.PlayerIndex);
        }

        /// <summary>
        /// Event handler for when the Exit Game menu entry is selected.
        /// </summary>
        void ExitGameMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            // Exit game code
        }


        void DebugMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new DebugMenuScreen(), e.PlayerIndex);
        }

        #endregion
    }
}
