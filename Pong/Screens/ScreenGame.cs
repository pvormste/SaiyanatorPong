using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pong.Components;
using Pong.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.Screens
{
    public class ScreenGame : Screen
    {

        private Texture2D background;
        private SpriteFont scoreFont;
        private SpriteFont normalFont;

        private int scorePlayer;
        private int scoreComputer;

        public ScreenGame(Game1 game) 
            : base(game)
        {
        }

        public override void Initialize()
        {
            // Background and fonts
            background = game.Content.Load<Texture2D>("img/pong_feld");
            scoreFont = game.Content.Load<SpriteFont>("fonts/Score");
            normalFont = game.Content.Load<SpriteFont>("fonts/NormalFont");

            // Scores
            scorePlayer = 0;
            scoreComputer = 0;

            // Player
            var player = new BaseObject(Entity.Player);
            player.AddComponent(new Sprite(game.GraphicsDevice, 25, 80, new Vector2(15, game.GraphicsDevice.Viewport.Height/2 - 40)));
            player.AddComponent(new PlayerInput(game));

            // Enemy
            var enemy = new BaseObject(Entity.Computer);
            enemy.AddComponent(new Sprite(game.GraphicsDevice, 25, 80, new Vector2(game.GraphicsDevice.Viewport.Width - 15 - 25, game.GraphicsDevice.Viewport.Height / 2 - 40)));
            enemy.AddComponent(new ComputerBehavior(game, this));

            // Ball
            var ball = new BaseObject(Entity.Ball);
            ball.AddComponent(new Sprite(game.GraphicsDevice, 30, 30, new Vector2(game.GraphicsDevice.Viewport.Width / 2 - 15, game.GraphicsDevice.Viewport.Height / 2 - 15)));
            ball.AddComponent(new BallBehavior(game, this));

            // Add Entities
            entities.AddEntity(player);
            entities.AddEntity(enemy);
            entities.AddEntity(ball);
        }

        public override void Unload()
        {

        }

        public override void Update(double gameTime)
        {
            entities.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // Draw Background
            spriteBatch.Draw(background, Vector2.Zero, Color.White);

            // Draw Player and Computer string
            spriteBatch.DrawString(normalFont, "Player", new Vector2(55, game.GraphicsDevice.Viewport.Height - 40), Color.SlateGray);
            spriteBatch.DrawString(normalFont, "Computer", new Vector2(game.GraphicsDevice.Viewport.Width - 155, game.GraphicsDevice.Viewport.Height - 40), Color.SlateGray);

            // Draw Scores
            spriteBatch.DrawString(scoreFont, scorePlayer.ToString(), new Vector2(330, 35), Color.White);
            spriteBatch.DrawString(scoreFont, scoreComputer.ToString(), new Vector2(440, 35), Color.White);
            
            // Draw Entities
            entities.Draw(spriteBatch);
        }

        public void GivePoint(Entity ent)
        {
            switch(ent)
            {
                case Entity.Player:
                    scorePlayer++; 
                    /*ResetState();*/ break;
                case Entity.Computer:
                    scoreComputer++;
                    /*ResetState();*/ break;
            }
        }

        private void ResetState()
        {
            var player = entities.FindEntity(Entity.Player);
            var computer = entities.FindEntity(Entity.Computer);

            var plSprite = player.GetComponent<Sprite>(ComponentType.Sprite);
            var compSprite = computer.GetComponent<Sprite>(ComponentType.Sprite);

            plSprite.Position = new Vector2(15, game.GraphicsDevice.Viewport.Height/2 - 40);
            compSprite.Position = new Vector2(game.GraphicsDevice.Viewport.Width - 15 - 25, game.GraphicsDevice.Viewport.Height / 2 - 40);
        }
    }
}
