using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankGame.Screens
{
    class DebugMenuScreen : MenuScreen
    {
        #region Initialization

        public DebugMenuScreen()
            : base("Debug Menu")
        {
            MenuEntry scenarioMenuEntry = new MenuEntry("Scenario");
            MenuEntry backMenuEntry = new MenuEntry("Back");

            scenarioMenuEntry.Selected += ScenarioMenuEntrySelected;
            backMenuEntry.Selected += BackMenuEntrySelected;

            MenuEntries.Add(scenarioMenuEntry);
            MenuEntries.Add(backMenuEntry);
        }


        #endregion

        #region Handle Input


        void ScenarioMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new ScenarioScreen(), e.PlayerIndex);
        }


        void BackMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new MainMenuScreen(), e.PlayerIndex);
        }


        #endregion
    }
}
