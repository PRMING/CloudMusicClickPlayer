using Hardcodet.Wpf.TaskbarNotification;
using Microsoft.Toolkit.Uwp.Notifications;
using System.ComponentModel;
using System.Windows;
using 午休网易云播放器.Class;

namespace 午休网易云播放器
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // 托盘图标
        private TaskbarIcon _tb;

        public MainWindow()
        {
            // 条件编译
#if DEBUG
            Title = $"{StaticData.AppName} 开发版";
#else
            Title = $"{StaticData.AppName}";
#endif

            // 获取数据
            StaticData.SetStaticData();

            // 启动托盘图标
            _tb = (TaskbarIcon)FindResource("Taskbar");

            InitializeComponent();

            // 启动检测打开界面
            MainFrame.Source = new Uri($"Pages/{StaticData.StartPage}.xaml", UriKind.RelativeOrAbsolute);

            // 窗体居中
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // 关闭窗口 触发事件
            Closing += WindowClosing;
        }

        // 关闭窗口 触发的事件
        private void WindowClosing(object sender, CancelEventArgs e)
        {
            // 通知
            new ToastContentBuilder()
                .AddArgument("action", "viewConversation")
                .AddArgument("conversationId", 9813)
                .AddText("窗口已收到托盘")
                .AddText("点击恢复恢复窗口")
                .Show();
        }

        
        // 切换界面
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