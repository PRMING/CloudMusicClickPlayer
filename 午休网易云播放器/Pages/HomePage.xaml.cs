using System.Windows;
using System.Windows.Controls;

namespace 午休网易云播放器.Pages
{
    /// <summary>
    /// HomePage.xaml 的交互逻辑
    /// </summary>
    public partial class HomePage : Page
    {
        // 计时器
        private Timer timer;

        // 当前时间
        DateTime nowTime;

        public HomePage()
        {
            InitializeComponent();

            // 判断是否已经点击按钮
            if (StaticData.IsStartButtonClick)
            {
                StartButton.IsEnabled = false;
                StartButton.Content = "已启动";
            }
        }

        // 计时器函数
        private void UpdateUITimerCallback(object state)
        {
            Dispatcher.Invoke(() =>
            {
                nowTime = DateTime.Now;

                if (nowTime.Hour == StaticData.BeginHour && nowTime.Minute == StaticData.BeginMinute)
                {
                    MethodClass methodClass = new();
                    methodClass.TaskStartMusic(StaticData.MusicName,StaticData.LateTime);

                    Environment.Exit(0);
                }
            });
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (StaticData.MusicName == "")
            {
                MessageBox.Show("请在 设置 输入播放歌曲名称");
                return;
            }

            // 开始计时器
            timer = new Timer(UpdateUITimerCallback, null, 0, 1000);



            StartButton.IsEnabled = false;

            StartButton.Content = "已启动";

            StaticData.IsStartButtonClick = true;

            //MethodClass methodClass = new();
            //methodClass.TaskStartMusic();
        }
    }
}
