using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pong.Manager;

namespace Pong.Screens
{
    public class ScreenTitle : Screen
    {
        private Texture2D title;

        public ScreenTitle(Game1 game)
            : base(game)
        {
        }

        public override void Initialize()
        {
            title = game.Content.Load<Texture2D>("img/pong");
            ManagerInput.InputHandler += OnInput;
        }

        public override void Unload()
        {
            ManagerInput.InputHandler -= OnInput;
        }

        public override void Update(double gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(title, new Vector2(0, 0), Color.White);
        }

        public void OnInput(object sender, InputEventArgs e)
        {
            if(e.Input == Input.None)
            {
                game.MgrScreen.ChangeScreen(new ScreenGame(game));
            }
        }
    }
}
