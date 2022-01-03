using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DiscordWidgetDisplay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Settings = Settings.Load();
            InitializeAsync();
        }

        private Settings Settings { get; set; }

        async void InitializeAsync()
        {
            if (Settings.LastVoiceLocation is not null)
            {
                webView.Source = new Uri(Settings.LastVoiceLocation);
                VoiceAddressBox.Text = Settings.LastVoiceLocation;
            }
            await webView.EnsureCoreWebView2Async();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void VoiceAddressGoButton(object sender, RoutedEventArgs e)
        {
            NavigateVoice(VoiceAddressBox.Text);
        }

        private void VoiceAddressBoxKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                NavigateVoice(VoiceAddressBox.Text);
            }
        }

        private void NavigateVoice(string location, bool save = true)
        {
            webView.CoreWebView2.Navigate(VoiceAddressBox.Text);
            if (save)
            {
                Settings.LastVoiceLocation = VoiceAddressBox.Text;
                Settings.Save();
            }
        }
    }
}
