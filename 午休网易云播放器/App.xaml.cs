using System.Windows;
using Windows.Foundation.Collections;
using Microsoft.Toolkit.Uwp.Notifications;

namespace 午休网易云播放器
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        App()
        {
            // 监听通知激活(点击)
            ToastNotificationManagerCompat.OnActivated += toastArgs =>
            {
                // Obtain the arguments from the notification
                ToastArguments args = ToastArguments.Parse(toastArgs.Argument);

                // Obtain any user input (text boxes, menu selections) from the notification
                ValueSet userInput = toastArgs.UserInput;

                // Need to dispatch to UI thread if performing UI operations
                Application.Current.Dispatcher.Invoke(delegate
                {
                    // 启动窗口
                    Application.Current.MainWindow = new MainWindow();
                    Application.Current.MainWindow.Show();
                });
            };
        }
    }
}