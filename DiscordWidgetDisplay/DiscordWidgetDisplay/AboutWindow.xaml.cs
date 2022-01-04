using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DiscordWidgetDisplay
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
        }

        public string Version => Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "";

        private void DiscordStreamkitCLicked(object sender, RoutedEventArgs e)
        {
            OpenUrl("https://streamkit.discord.com/overlay");
        }

        private void GithubRepoClicked(object sender, RoutedEventArgs e)
        {
            OpenUrl("https://github.com/pingu2k4/DiscordWidgetDisplay");
        }

        private void OpenDataFolder(object sender, RoutedEventArgs e)
        {
            OpenUrl(Settings.DataFilePath);
        }

        private void OpenUrl(string location)
        {
            System.Diagnostics.Process.Start("explorer", location);
        }
    }
}
