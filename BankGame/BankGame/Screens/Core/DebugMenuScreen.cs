using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankGame.Screens.Debug;

namespace BankGame.Screens
{
    class DebugMenuScreen : MenuScreen
    {
        #region Initialization

        public DebugMenuScreen()
            : base("Debug Menu")
        {
            MenuEntry scenarioMenuEntry = new MenuEntry("Scenario");
            MenuEntry characterMenuEntry = new MenuEntry("Character");
            MenuEntry backMenuEntry = new MenuEntry("Back");

            scenarioMenuEntry.Selected += ScenarioMenuEntrySelected;
            characterMenuEntry.Selected += CharacterMenuEntrySelected;
            backMenuEntry.Selected += BackMenuEntrySelected;

            MenuEntries.Add(scenarioMenuEntry);
            MenuEntries.Add(characterMenuEntry);
            MenuEntries.Add(backMenuEntry);
        }


        #endregion

        #region Handle Input


        void ScenarioMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new ScenarioScreen(), e.PlayerIndex);
        }

        void CharacterMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new CharacterTestScreen(), e.PlayerIndex);
        }

        void BackMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new MainMenuScreen(), e.PlayerIndex);
        }


        #endregion
    }
}
