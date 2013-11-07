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
            MenuEntry inputMenuEntry = new MenuEntry("Input");
            //MenuEntry characterMenuEntry = new MenuEntry("Character");
            MenuEntry backMenuEntry = new MenuEntry("Back");

            scenarioMenuEntry.Selected += ScenarioMenuEntrySelected;
            inputMenuEntry.Selected += InputMenuEntrySelected;
            //characterMenuEntry.Selected += CharacterMenuEntrySelected;
            backMenuEntry.Selected += BackMenuEntrySelected;

            MenuEntries.Add(scenarioMenuEntry);
            MenuEntries.Add(inputMenuEntry);
            //MenuEntries.Add(characterMenuEntry);
            MenuEntries.Add(backMenuEntry);
        }


        #endregion

        #region Handle Input


        void ScenarioMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new ScenarioScreen(), e.PlayerIndex);
        }

        void InputMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new InputDebugScreen(), e.PlayerIndex);
        }
       /* void CharacterMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new CharacterTestScreen(), e.PlayerIndex);
        }*/

        void BackMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new MainMenuScreen(), e.PlayerIndex);
        }


        #endregion
    }
}
