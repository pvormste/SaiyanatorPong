using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.Components
{
    public class Sprite : Component
    {
        private Texture2D texture;

        public float Speed { get; set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Vector2 Position { get; set; }

        public Sprite(GraphicsDevice graphicsDevice, int width, int height, Vector2 pos)
        {
            Width = width;
            Height = height;

            texture = new Texture2D(graphicsDevice, Width, Height);
            Color[] color = new Color[Width * Height];

            for (int i = 0; i < color.Length; ++i)
            {
                color[i] = Color.White;
            }

            texture.SetData<Color>(color);

            Position = pos;
            Speed = 0.25f;
        }

        public override ComponentType ComponentType
        {
            get { return ComponentType.Sprite; }
        }

        public override void Update(double gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, Color.White);
        }
    }
}
