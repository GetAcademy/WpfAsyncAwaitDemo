using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfAsyncAwaitDemo
{
    class UrlInspectorPanel : StackPanel
    {
        private TextBox _textBox;
        private Button _button;
        private Label _label;

        public UrlInspectorPanel()
        {
            _textBox = new TextBox();
            _button = new Button() {Content = "Les URL"};
            _button.Click += _button_Click3;
            _label = new Label();
            Children.Add(_textBox);
            Children.Add(_button);
            Children.Add(_label);
        }

        private async void _button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var html = await MyGetUrlMethod(_textBox.Text);
            _label.Content = $"{html.Length} bytes. {html.Substring(0, 50)}";
        }

        private void _button_Click2(object sender, System.Windows.RoutedEventArgs e)
        {
            MyGetUrlMethod(_textBox.Text).ContinueWith(Show);
        }

        private void _button_Click3(object sender, System.Windows.RoutedEventArgs e)
        {
            GetAndShowUrl(_textBox.Text);
        }

        private void Show(Task<string> obj)
        {
            var html = obj.Result;
            _label.Content = $"{html.Length} bytes. {html.Substring(0, 50)}";
        }

        async Task GetAndShowUrl(string url)
        {
            var html = await MyGetUrlMethod(url);
            _label.Content = $"{html.Length} bytes. {html.Substring(0, 50)}";
        }

        private async Task<string> MyGetUrlMethod(string url)
        {
            var webClient = new WebClient();
            if (!url.StartsWith("https://")) url = "https://" + url;
            var html = await webClient.DownloadStringTaskAsync(url);
            return html;
        }
    }
}
