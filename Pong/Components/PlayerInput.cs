using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.Components
{
    public class PlayerInput : Component
    {
        Game1 game;

        public PlayerInput(Game1 game)
        {
            this.game = game;

            ManagerInput.InputHandler -= OnInput;
            ManagerInput.InputHandler += OnInput;  
        }

        public override ComponentType ComponentType
        {
            get { return ComponentType.PlayerInput; }
        }

        public override void Update(double gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
        }

        public void OnInput(object sender, InputEventArgs e)
        {
            var sprite = GetComponent<Sprite>(ComponentType.Sprite);
            if (sprite == null)
                return;

            switch (e.Input)
            {
                case Input.Up:
                    if (sprite.Position.Y - sprite.Speed == 0)
                        return;

                    if(sprite.Position.Y - sprite.Speed < 0)
                    {
                        while (sprite.Position.Y > 0)
                            sprite.Position = new Vector2(sprite.Position.X, sprite.Position.Y - 1);

                        return;
                    }

                    sprite.Position += new Vector2(0, -sprite.Speed * (float)e.GameTime); break;
                case Input.Down:
                    if ((sprite.Position.Y + sprite.Height + sprite.Speed) == game.GraphicsDevice.Viewport.Height)
                        return;

                    if((sprite.Position.Y + sprite.Height + sprite.Speed) > game.GraphicsDevice.Viewport.Height)
                    {
                        while ((sprite.Position.Y + sprite.Height) < game.GraphicsDevice.Viewport.Height)
                            sprite.Position = new Vector2(sprite.Position.X, sprite.Position.Y + 1);

                        return;
                    }

                    sprite.Position += new Vector2(0, sprite.Speed * (float)e.GameTime); break;
            }
        }
    }
}
