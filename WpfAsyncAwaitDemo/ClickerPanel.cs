using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp7
{
    class ClickerPanel : StackPanel
    {
        private Label _label;
        private int _count;
        public ClickerPanel()
        {
            var button = new Button() { Content = "Klikk her" };
            _label = new Label();
            button.Click += ButtonClick;
            Children.Add(button);
            Children.Add(_label);
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            _count++;
            _label.Content = _count;
        }
    }
}
