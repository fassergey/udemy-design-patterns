using System;
using System.Windows;
using static System.Console;

namespace Observer
{
    public class Button
    {
        public event EventHandler Clicked;

        public void Fire()
        {
            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Window
    {
        public Window(Button button)
        {
            // button.Clicked += ButtonClicked;
            WeakEventManager<Button, EventArgs>.AddHandler(button, "Clicked", ButtonClicked);       // !!!!!!!!!!!!!!!!!
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            WriteLine("Button clicked (window handler)");
        }

        ~Window()
        {
            WriteLine("Window is finalized");
        }
    }
}
