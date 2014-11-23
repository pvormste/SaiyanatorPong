using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pong.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.Screens
{
    public abstract class Screen
    {
        protected Entities entities;
        protected Game1 game;

        public Entities Entities { get { return entities; } }

        public Screen(Game1 game)
        {
            this.game = game;
            entities = new Entities();
        }

        public abstract void Initialize();
        public abstract void Unload();
        public abstract void Update(double gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
