using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankGame.Screens
{
    class OptionsScreen : MenuScreen
    {
        #region Initialization

        /// <summary>
        /// Constructor fills in the option menu contents.
        /// </summary>
        public OptionsScreen()
            : base("Options")
        {
            // Create our option entries
            MenuEntry gameplayMenuEntry = new MenuEntry("Gameplay");
            MenuEntry displayMenuEntry = new MenuEntry("Display");
            MenuEntry audioMenuEntry = new MenuEntry("Audio");
            MenuEntry controlsMenuEntry = new MenuEntry("Controls");
            MenuEntry backMenuEntry = new MenuEntry("Back");

            // Hook up menu event handlers
            gameplayMenuEntry.Selected += GameplayMenuEntrySelected;
            displayMenuEntry.Selected += DisplayMenuEntrySelected;
            audioMenuEntry.Selected += AudioMenuEntrySelected;
            controlsMenuEntry.Selected += ControlsMenuEntrySelected;
            backMenuEntry.Selected += BackMenuEntrySelected;

            // Add entries to the options menu
            MenuEntries.Add(gameplayMenuEntry);
            MenuEntries.Add(displayMenuEntry);
            MenuEntries.Add(audioMenuEntry);
            MenuEntries.Add(controlsMenuEntry);
            MenuEntries.Add(backMenuEntry);
        }


        #endregion

        #region Handle Input


        /// <summary>
        /// Event handler for when the Gameplay menu entry is selected.
        /// </summary>
        void GameplayMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            // Add logic for gameplay options menu here
        }


        /// <summary>
        /// Event handler for when the Display menu entry is selected.
        /// </summary>
        void DisplayMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            // Add logic for display options menu here
        }


        /// <summary>
        /// Event handler for when the Audio menu entry is selected.
        /// </summary>
        void AudioMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            // Add logic for audio options menu here
        }


        /// <summary>
        /// Event handler for when the Controls menu entry is selected.
        /// </summary>
        void ControlsMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            // Add logic for controls options menu here
        }


        /// <summary>
        /// Event handler for when the Back menu entry is selected.
        /// </summary>
        void BackMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            // Go back to main menu.
            ScreenManager.RemoveScreen(this);
        }


        #endregion
    }

}
