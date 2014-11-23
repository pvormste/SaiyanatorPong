using Microsoft.Xna.Framework;
using Pong.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.Components
{
    class BallBehavior : Component
    {
        private Game1 _game;
        private ScreenGame _screenGame;

        private Sprite _sprite;
        private Vector2 _movementDir;
        private float _speedModifier;

        public Vector2 Speed { get { return _movementDir;  } }

        public BallBehavior(Game1 game, ScreenGame screenGame)
        {
            _game = game;
            _screenGame = screenGame;
        }

        public override ComponentType ComponentType
        {
            get { return ComponentType.BallBehavior; }
        }

        public override void Initialize(BaseObject baseObject)
        {
            base.Initialize(baseObject);

            _sprite = baseObject.GetComponent<Sprite>(ComponentType.Sprite);
            _speedModifier = 12;
            StartObject();
        }

        public void StartObject()
        {
            _sprite.Position = new Vector2(_game.GraphicsDevice.Viewport.Width / 2 - 15, _game.GraphicsDevice.Viewport.Height / 2 - 15);
            _movementDir = StartRandMovementDir();
        }

        public override void Update(double gameTime)
        {
            _sprite.Position += _movementDir;

            // Collision CHeck
            CollisionCheck();

            // Border check
            if(_sprite.Position.Y < 0)
            {
                _sprite.Position = new Vector2(_sprite.Position.X, 0);
                BounceAtBorder();
            }
            if((_sprite.Position.Y + _sprite.Height) > _game.GraphicsDevice.Viewport.Height)
            {
                _sprite.Position = new Vector2(_sprite.Position.X, (_game.GraphicsDevice.Viewport.Height - _sprite.Height));
                BounceAtBorder();
            }

            // Point checking
            if(_sprite.Position.X < 0 )
            {
                _screenGame.GivePoint(Entity.Computer);
                StartObject();
                return;
            }

            if((_sprite.Position.X + _sprite.Width) > _game.GraphicsDevice.Viewport.Width)
            {
                _screenGame.GivePoint(Entity.Player);
                StartObject();
                return;
            }

        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
        }

        private Vector2 StartRandMovementDir()
        {
            Random rndNum = new Random();

            float og = _sprite.Speed * 100;

            float rndX = (float)rndNum.Next(25, (int)og * 2) * 0.01f;
            float rndY = (float)rndNum.Next(30, (int)og * 2) * 0.01f;

            switch(rndNum.Next(0, 4))
            {
                case 0:
                    rndX *= -1; break;
                case 1:
                    rndY *= -1; break;
                case 2:
                    rndX *= -1;
                    rndY *= -1; break;
                default:
                    break;
            }

            return new Vector2(_speedModifier*rndX, _speedModifier*rndY);
        }

        private void BounceAtBorder()
        {
            _movementDir = new Vector2(_movementDir.X, _movementDir.Y * -1);
        }

        private void CollisionCheck()
        {
            var player = _screenGame.Entities.FindEntity(Entity.Player).GetComponent<Sprite>(ComponentType.Sprite);
            var computer = _screenGame.Entities.FindEntity(Entity.Computer).GetComponent<Sprite>(ComponentType.Sprite);


            if(IsCollidingWith(player))
            {
                if (_sprite.Position.X < (player.Position.X + player.Width) && _sprite.Position.X > (player.Position.X + player.Width + _movementDir.X - 2)
                    && (_sprite.Position.X - _movementDir.X < (player.Position.X + player.Width - _movementDir.X)))
                {
                    _sprite.Position = new Vector2(player.Position.X + player.Width, _sprite.Position.Y);
                    _movementDir = new Vector2(_movementDir.X * -1, _movementDir.Y);
                    SpeedUpBall();
                    return;
                }

                /*if(_sprite.Position.X < (player.Position.X + player.Width) && (_sprite.Position.X - _movementDir.X < (player.Position.X + player.Width - _movementDir.X))
                    && _sprite.Position.Y < (player.Position.Y + player.Height) && (_sprite.Position.Y + _sprite.Height) > player.Position.Y)
                {
                    _sprite.Position = new Vector2(player.Position.X + player.Width, _sprite.Position.Y);
                    _movementDir = new Vector2(_movementDir.X * -1, _movementDir.Y);
                    return;
                }
                if (_sprite.Position.Y < (player.Position.Y + player.Height) && (_sprite.Position.Y - _movementDir.Y < (player.Position.Y + player.Height - _movementDir.Y))
                    && _sprite.Position.X < (player.Position.X + player.Width) && (_sprite.Position.X + _sprite.Width) > player.Position.X)
                {
                    _sprite.Position = new Vector2(_sprite.Position.X, player.Position.Y + player.Height);
                    _movementDir = new Vector2(_movementDir.X, _movementDir.Y * -1);
                    return;
                }
                if ((_sprite.Position.Y + _sprite.Height) > player.Position.Y && (_sprite.Position.Y + _sprite.Height - _movementDir.Y < (player.Position.Y - _movementDir.Y))
                    && _sprite.Position.X < (player.Position.X + player.Width) && (_sprite.Position.X + _sprite.Width) > player.Position.X)
                {
                    _sprite.Position = new Vector2(_sprite.Position.X, player.Position.Y - _sprite.Height);
                    _movementDir = new Vector2(_movementDir.X, _movementDir.Y * -1);
                    return;
                }*/
            }

            if(IsCollidingWith(computer))
            {
                if ((_sprite.Position.X + _sprite.Width) > computer.Position.X && (_sprite.Position.X + _sprite.Width) < (computer.Position.X + _movementDir.X + 2)
                       && ((_sprite.Position.X + _sprite.Width - _movementDir.X) > (computer.Position.X - _movementDir.X)))
                {
                    _sprite.Position = new Vector2(computer.Position.X - _sprite.Width, _sprite.Position.Y);
                    _movementDir = new Vector2(_movementDir.X * -1, _movementDir.Y);
                    SpeedUpBall();
                    return;
                }
            }
        }

        private bool IsCollidingWith(Sprite other)
        {
            Rectangle otherRectangle = new Rectangle((int)other.Position.X, (int)other.Position.Y, other.Width, other.Height);
            Rectangle ballRectangle = new Rectangle((int)_sprite.Position.X, (int)_sprite.Position.Y, _sprite.Width, _sprite.Height);

            if(ballRectangle.Intersects(otherRectangle))
            {
                return true;
            }

            return false;
        }

        private void SpeedUpBall()
        {
            _movementDir *= 1.15f;
        }
    }
}
