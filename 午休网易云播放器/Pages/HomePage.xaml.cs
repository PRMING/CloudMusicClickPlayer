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

        // 点击时获取音乐的名字避免再次修改
        private string willBeginMusic;

        // 计时器函数
        private void UpdateUITimerCallback(object state)
        {
            Dispatcher.Invoke(() =>
            {
                nowTime = DateTime.Now;

                if (nowTime.Hour == StaticData.BeginHour && nowTime.Minute == StaticData.BeginMinute)
                {
                    MethodClass methodClass = new();
                    methodClass.TaskStartMusic(willBeginMusic, StaticData.LateTime);
                    // 删除音乐
                    StaticData.MusicDataList[0] = "";
                    // 音乐排序
                    methodClass.MusicSort();

                    Environment.Exit(0);
                }
            });
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (StaticData.MusicDataList[0] == "")
            {
                MessageBox.Show("请在 歌曲 中添加至少一首音乐");
                return;
            }

            willBeginMusic = StaticData.MusicDataList[0];
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
