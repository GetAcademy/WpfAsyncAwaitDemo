using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp7
{
    class Program
    {
        private static Label _label;
        private static int _count;

        [STAThread]
        public static void Main()
        {
            var application = new Application();
            var window = new Window();

            var panel = new StackPanel();
            panel.Children.Add(new ClickerPanel());
            panel.Children.Add(new ClickerPanel());
            panel.Children.Add(new ClickerPanel());
            panel.Children.Add(new ClickerPanel());
            window.Content = panel;

            application.Run(window);
        }


    }
}
