#region Using Statements
using Microsoft.Xna.Framework;
#endregion

namespace BankGame.Screens
{
    /// <summary>
    /// The New Game Menu screen is displayed when the user selects
    /// New Game from the Main Menu.  The player selects the difficulty
    /// of the game, then moves into the opening intro sequence.
    /// </summary>
    class NewGameMenuScreen : MenuScreen
    {
        #region Initialization


        /// <summary>
        /// The constructor fills in the menu contents.
        /// </summary>
        public NewGameMenuScreen()
            : base("Select Difficulty")
        {
            // Create our menu entries
            MenuEntry easyMenuEntry = new MenuEntry("Easy");
            MenuEntry normalMenuEntry = new MenuEntry("Normal");
            MenuEntry hardMenuEntry = new MenuEntry("Hard");
            MenuEntry eliteMenuEntry = new MenuEntry("Elite");
            MenuEntry backMenuEntry = new MenuEntry("Go Back");

            // Hook up menu event handlers
            easyMenuEntry.Selected += EasyMenuEntrySelected;
            normalMenuEntry.Selected += NormalMenuEntrySelected;
            hardMenuEntry.Selected += HardMenuEntrySelected;
            eliteMenuEntry.Selected += EliteMenuEntrySelected;
            backMenuEntry.Selected += BackMenuEntrySelected;

            // Add entries to the menu
            MenuEntries.Add(easyMenuEntry);
            MenuEntries.Add(normalMenuEntry);
            MenuEntries.Add(hardMenuEntry);
            MenuEntries.Add(eliteMenuEntry);
            MenuEntries.Add(backMenuEntry);
        }


        #endregion

        #region Handle Input


        /// <summary>
        /// Event handler for when the Easy menu entry is selected.
        /// </summary>
        void EasyMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            LoadIntroSequence(e);
        }

        /// <summary>
        /// Event handler for when the Normal menu entry is selected.
        /// </summary>
        void NormalMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            LoadIntroSequence(e);
        }

        /// <summary>
        /// Event handler for when the Hard menu entry is selected.
        /// </summary>
        void HardMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            LoadIntroSequence(e);
        }

        /// <summary>
        /// Event handler for when the Elite menu entry is selected.
        /// </summary>
        void EliteMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            LoadIntroSequence(e);
        }

        /// <summary>
        /// Event handler for when the Back menu entry is selected.
        /// </summary>
        void BackMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            LoadingScreen.Load(ScreenManager, false, e.PlayerIndex,
                               new MainMenuScreen());
        }


        /// <summary>
        /// Loads the intro sequence.
        /// </summary>
        /// <param name="e"></param>
        void LoadIntroSequence(PlayerIndexEventArgs e)
        {
            LoadingScreen.Load(ScreenManager, true, e.PlayerIndex,
                               new IntroSequenceScreen());
        }


        #endregion
    }
}
