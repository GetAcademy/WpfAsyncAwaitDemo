using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfAsyncAwaitDemo;

namespace WpfApp7
{
    class Program
    {
        private static Label _label;
        private static int _count;

        [STAThread]
        public static void Main()
        {
            //MainAsync("www.vg.no").Wait();
            //var task = MainAsync("www.vg.no");
            //task.Wait();
            //Step2().Wait();
            //return;
            var application = new Application();
            var window = new Window();

            var panel = new StackPanel();
            panel.Children.Add(new UrlInspectorPanel());
            panel.Children.Add(new ClickerPanel());
            panel.Children.Add(new ClickerPanel());
            panel.Children.Add(new ClickerPanel());
            panel.Children.Add(new ClickerPanel());
            window.Content = panel;

            application.Run(window);
        }

        public static async Task MainAsync(string url)
        {
            var webClient = new WebClient();
            if (!url.StartsWith("https://")) url += "https://";
            var html = await webClient.DownloadStringTaskAsync(url);
            Console.WriteLine("A");
        }

        public static async Task Step2()
        {
            Console.WriteLine("B");
        }
    }
}
