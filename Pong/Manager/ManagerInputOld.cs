using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.Manager
{
    /*class ManagerInputOld
    {
        private KeyboardState _keyState;
        private KeyboardState _lastKeyState;
        private Keys _lastKey;

        private double _counter;
        private static bool _isPaused;
        private static double _cooldown;
        private static double _pauseCounter;
        private static double _pauseTime;

        public static bool ThrottleInput { get; set; }
        public static bool LockMovement { get; set; }
        
        private static event EventHandler<InputEventArgs> _inputHandler;

        public static event EventHandler<InputEventArgs> InputHandler
        {
            add { _inputHandler += value; }
            remove { _inputHandler -= value; }
        }

        public ManagerInputOld()
        {
            ThrottleInput = false;
            LockMovement = false;
            _counter = 0;
            _lastKey = Keys.None;
        }

        public void Update(double gameTime)
        {
            if (_isPaused)
            {
                _pauseCounter += gameTime;
                if (_pauseCounter > _pauseTime)
                {
                    _isPaused = false;
                    _pauseCounter = 0;
                }
                else
                    return;      
            }

            if (_cooldown > 0)
            {
                _counter += gameTime;
                if (_counter > gameTime)
                {
                    _counter = 0;
                    _cooldown = 0;
                }
                else
                    return;
            }

            CheckControls(gameTime);
        }

        public void CheckControls(double gameTime)
        {
            _keyState = Keyboard.GetState();

            // Reset Keystate
            if (_lastKey != Keys.None && _keyState.IsKeyUp(_lastKey))
            {
                if(_inputHandler != null)
                    _inputHandler(this, new InputEventArgs(Input.None));

            }

            checkForKey(Keys.Up, Input.Up);

            _lastKeyState = _keyState;
        }

        private void checkForKey(Keys key, Input input)
        {
            if (_keyState.IsKeyDown(key))
            {
                if (!ThrottleInput || (ThrottleInput && _lastKeyState.IsKeyUp(key)))
                {
                    if(_inputHandler != null)
                    {
                        _inputHandler(this, new InputEventArgs(input));
                        _lastKey = key;
                    }
                }
            }
        }

        public static void PauseInput(double milliseconds)
        {
            _pauseTime = milliseconds;
            _isPaused = true;
        }


    }

    class InputEventArgs : EventArgs 
    {
        public Input Input { get; private set; }

        public InputEventArgs(Input input)
        {
            Input = input;
        } 
    }*/
}
