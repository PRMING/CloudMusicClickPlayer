using System.Diagnostics;
using System.Windows;

namespace 午休网易云播放器
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            StaticData.SetStaticData();

            InitializeComponent();

#if DEBUG
            Title = $"{StaticData.AppName} 开发版";
#else
            Title = $"{StaticData.AppName}";
#endif

            // 窗体居中
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void HomePageButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Source = new Uri("Pages/HomePage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void MusicDataPageButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Source = new Uri("Pages/MusicDataPage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void SettingPageButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Source = new Uri("Pages/SettingPage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void AboutPageButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Source = new Uri("Pages/AboutPage.xaml", UriKind.RelativeOrAbsolute);
        }
    }
}