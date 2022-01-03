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
                VoiceWebView.Source = new Uri(SantizeUrl(Settings.LastVoiceLocation));
                VoiceAddressBox.Text = Settings.LastVoiceLocation;
            }

            if(Settings.LastChatLocation is not null)
            {
                ChatWebView.Source = new Uri(SantizeUrl(Settings.LastChatLocation));
                ChatAddressBox.Text = Settings.LastChatLocation;
            }

            if (Settings.Top is not null)
            {
                this.Top = Settings.Top.Value;
            }
            if (Settings.Left is not null)
            {
                this.Left = Settings.Left.Value;
            }

            ShowVoiceToggle.IsChecked = Settings.VoiceVisible;
            ShowChatToggle.IsChecked = Settings.ChatVisible;

            await VoiceWebView.EnsureCoreWebView2Async();
            await ChatWebView.EnsureCoreWebView2Async();

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
            SaveWindowLocation();
        }

        private void SaveWindowLocation()
        {
            Settings.Top = this.Top;
            Settings.Left = this.Left;
            Settings.Save();
        }

        private void VoiceAddressGoButton(object sender, RoutedEventArgs e)
        {
            NavigateVoice(VoiceAddressBox.Text);
        }

        private void ChatAddressGoButton(object sender, RoutedEventArgs e)
        {
            NavigateChat(ChatAddressBox.Text);
        }

        private void ReloadClicked(object sender, RoutedEventArgs e)
        {
            VoiceWebView.Reload();
            ChatWebView.Reload();
        }

        private void VoiceAddressBoxKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                NavigateVoice(VoiceAddressBox.Text);
            }
        }

        private void ChatAddressBoxKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                NavigateChat(ChatAddressBox.Text);
            }
        }

        private string SantizeUrl(string location)
        {
            if(!location.StartsWith("http"))
            {
                location = "https://" + location;
            }

            return location.Replace("limit_speaking=true", "limit_speaking=True");
        }

        private void NavigateVoice(string location)
        {
            VoiceWebView.CoreWebView2.Navigate(SantizeUrl(location));
            Settings.LastVoiceLocation = location;
            Settings.Save();
        }

        private void NavigateChat(string location)
        {
            ChatWebView.CoreWebView2.Navigate(SantizeUrl(location));
            Settings.LastChatLocation = location;
            Settings.Save();
        }

        private void VoiceToggleChanged(object sender, RoutedEventArgs e)
        {
            Settings.VoiceVisible = ShowVoiceToggle.IsChecked ?? true;
            Settings.Save();
        }

        private void ChatToggleChanged(object sender, RoutedEventArgs e)
        {
            Settings.ChatVisible = ShowChatToggle.IsChecked ?? true;
            Settings.Save();
        }

        private void AboutClicked(object sender, RoutedEventArgs e)
        {
            var aboutWindow = new AboutWindow();
            aboutWindow.ShowDialog();
        }
    }
}
