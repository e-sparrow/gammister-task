using System;
using System.Collections.Generic;
using System.Linq;
using Utils.Screens.Interfaces;

namespace Utils.Screens
{
    public class ScreenService : IScreenService
    {
        private readonly Queue<IScreen> _screens = new Queue<IScreen>();

        private IHiddable _activeScreen;
        
        public void ShowScreen(IScreen screen)
        {
            _activeScreen?.Hide();
            _activeScreen = screen;
            _screens.Enqueue(screen);
            
            screen.Show();
        }

        public void ShowScreen<TArgument>(IScreen<TArgument> screen, TArgument argument)
        {
            _activeScreen?.Hide();
            _activeScreen = screen;

            var value = new ScreenDummy(ShowValue, HideValue);
            _screens.Enqueue(value);
            
            ShowValue();

            void ShowValue()
            {
                screen.Show(argument);
            }

            void HideValue()
            {
                screen.Hide();   
            }
        }

        public void Back()
        {
            var current = _screens.Dequeue();
            current.Hide();

            var hasNext = _screens.Any();
            if (hasNext)
            {
                var next = _screens.Peek();
                
                _activeScreen = next;
                next.Show();
            }
        }

        public void Hide()
        {
            _screens.Clear();
            
            _activeScreen.Hide();
            _activeScreen = null;
        }

        private class ScreenDummy : IScreen
        {
            public ScreenDummy(Action show, Action hide)
            {
                _show = show;
                _hide = hide;
            }

            private readonly Action _show;
            private readonly Action _hide;
            
            public void Show()
            {
                _show.Invoke();
            }

            public void Hide()
            {
                _hide.Invoke();
            }
        }
    }
}