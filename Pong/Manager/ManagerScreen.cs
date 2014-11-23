using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Pong.Screens;
using Microsoft.Xna.Framework.Graphics;

namespace Pong.Manager
{
    public class ManagerScreen
    {
        private Stack<Screen> _screens;
        private Screen _lastScreen;

        public ManagerScreen()
        {
            _screens = new Stack<Screen>();
        }

        public Screen GetCurrentScreen()
        {
            return _screens.Peek();
        }

        public void ChangeScreen(Screen screen)
        {
            while(_screens.Count > 0)
            {
                RemoveScreen();
            }

            AddScreen(screen);
        }

        public void AddScreen(Screen screen)
        {
            _screens.Push(screen);
            screen.Initialize();
        }

        public void PreviousScreen()
        {
            if (_lastScreen != null)
                ChangeScreen(_lastScreen);
        }

        private void RemoveScreen()
        {
            _lastScreen = _screens.Pop();
            _lastScreen.Unload();
        }

        public void Update(double gameTime)
        {
            GetCurrentScreen().Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            GetCurrentScreen().Draw(spriteBatch);
        }
    }
}
