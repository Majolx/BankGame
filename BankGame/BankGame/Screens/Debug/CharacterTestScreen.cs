using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BankGame.Screens
{
    class CharacterTestScreen : GameScreen
    {
        private BaseCharacter testCharacter;
        private string output;

        public CharacterTestScreen()
        {
            testCharacter = new BaseCharacter();
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;

            output = "Name: " + testCharacter.Name +
                  "\nLevel: " + testCharacter.Level;

            spriteBatch.Begin();
            spriteBatch.DrawString(ScreenManager.Font, output, new Vector2(0, 0), Color.White);
            spriteBatch.End();
        }
    }
}
