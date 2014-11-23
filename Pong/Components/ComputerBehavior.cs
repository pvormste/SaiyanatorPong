using Microsoft.Xna.Framework;
using Pong.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.Components
{
    class ComputerBehavior : Component
    {
        private Game1 _game;
        private ScreenGame _screenGame;
        private Sprite _sprite;
        private Sprite _ballSprite;
        private BallBehavior _BallBehavior;
        private float _centerPoint;

        public ComputerBehavior(Game1 game, ScreenGame screenGame)
        {
            _game = game;
            _screenGame = screenGame;
            _centerPoint = 0;
        }

        public override ComponentType ComponentType
        {
            get { return ComponentType.ComputerBehavior; }
        }

        public override void Update(double gameTime)
        {
            if (_ballSprite == null)
                _ballSprite = _screenGame.Entities.FindEntity(Entity.Ball).GetComponent<Sprite>(ComponentType.Sprite);

            if (_BallBehavior == null)
                _BallBehavior = _screenGame.Entities.FindEntity(Entity.Ball).GetComponent<BallBehavior>(ComponentType.BallBehavior);

            if (_sprite == null)
                _sprite = GetComponent<Sprite>(ComponentType.Sprite);

            if (_centerPoint == 0)
                _centerPoint = _sprite.Height / 2;

            if(_BallBehavior.Speed.X < 0)
            {
                if ((_sprite.Position.Y + _centerPoint) > _game.GraphicsDevice.Viewport.Height / 2 - 2)
                    _sprite.Position += new Vector2(0, -1.4f * _sprite.Speed * (float)gameTime);

                if ((_sprite.Position.Y + _centerPoint) < _game.GraphicsDevice.Viewport.Height / 2 + 2)
                    _sprite.Position += new Vector2(0, 1.4f * _sprite.Speed * (float)gameTime);
            }
            else if(_BallBehavior.Speed.X > 0)
            {
                if ((_ballSprite.Position.Y + (_ballSprite.Height / 2)) > (_sprite.Position.Y + _centerPoint) + 3)
                    _sprite.Position += new Vector2(0, 1.4f * _sprite.Speed * (float)gameTime);

                if ((_ballSprite.Position.Y + (_ballSprite.Height / 2)) < (_sprite.Position.Y + _centerPoint) - 3)
                    _sprite.Position += new Vector2(0, -1.4f * _sprite.Speed * (float)gameTime);
            }

            
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
        }
    }
}
