using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.Manager
{
    public class ManagerInput
    {
        private KeyboardState _keyboardState;
        private KeyboardState _lastKeyboardState;
        private Keys _lastKey;

        private bool _isCooldown;
        private double _cooldownCounter;

        private static double _pauseCounter;
        private static double _pauseTime;
        private static bool _isPaused;
        private static bool _isInputLocked;

        private static event EventHandler<InputEventArgs> _inputHandler;

        public static event EventHandler<InputEventArgs> InputHandler
        {
            add { _inputHandler += value; }
            remove { _inputHandler -= value; }
        }

        public ManagerInput()
        {
            _isCooldown = true;
            _isPaused = false;
            _isInputLocked = false;

            _pauseTime = 0;
            _cooldownCounter = 0;
            _pauseCounter = 0;

            _lastKey = Keys.None;
        }

        public void Update(double gameTime)
        {
            if (_isInputLocked)
                return;

            if (_isPaused)
            {
                _pauseCounter += gameTime;
                if (_pauseCounter > _pauseTime)
                {
                    _pauseCounter = 0;
                    _isPaused = false;
                }
                else
                    return;
            }

            if (_isCooldown)
            {
                _cooldownCounter += gameTime;
                if (_cooldownCounter > gameTime)
                {
                    _isCooldown = false;
                    _cooldownCounter = 0;
                }
                else
                    return;
            }

            CheckControls(gameTime);
        }

        private void CheckControls(double gameTime)
        {
            _keyboardState = Keyboard.GetState();

            if (_lastKey != Keys.None && _lastKeyboardState.IsKeyUp(_lastKey))
            {
                if (_inputHandler != null)
                    _inputHandler(this, new InputEventArgs(Input.None, gameTime));
            }

            CheckForKey(Keys.Up, Input.Up, gameTime);
            CheckForKey(Keys.Down, Input.Down, gameTime);
            CheckForKey(Keys.Enter, Input.Enter, gameTime);

            _lastKeyboardState = _keyboardState;
        }

        private void CheckForKey(Keys key, Input input, double gameTime)
        {
            if (_keyboardState.IsKeyDown(key))
            {
                if (_inputHandler != null)
                {
                    _inputHandler(this, new InputEventArgs(input, gameTime));
                    _lastKey = key;
                }

            }
        }

        public static void PauseInput(double milliseconds)
        {
            _pauseTime = milliseconds;
            _isPaused = true;
        }

        public static void LockMovement()
        {
            _isInputLocked = true;
        }

        public static void UnlockMovement()
        {
            _isInputLocked = false;
        }
    }

    public class InputEventArgs : EventArgs 
    {
        public Input Input { get; private set; }
        public double GameTime { get; private set; }

        public InputEventArgs(Input input, double gameTime)
        {
            Input = input;
            GameTime = gameTime;
        }
    }
}
