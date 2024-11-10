using Microsoft.Toolkit.Uwp.Notifications;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using 午休音乐播放器.Class;

namespace 午休音乐播放器.Pages
{
    /// <summary>
    /// HomePage.xaml 的交互逻辑
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();

            // 设置当前页面
            StaticData.StartPage = "HomePage";

            // 判断是否已经点击按钮
            if (StaticData.IsStartButtonClick)
            {
                StartButton.Content = "取消";
                CountDownTextBlock.Text = $"即将在 {StaticData.WillBeginHour}:{StaticData.WillBeginMinute} 播放 \"{StaticData.WillBeginMusic}\"";
            }
            else
            {
                StartButton.Content = "启动";
                CountDownTextBlock.Text = tip;
            }

            switch (StaticData.StartMusicMethodType)
            {
                case 0:
                    {
                        MainTitleIcon.Source = new BitmapImage(new System.Uri("/Resources/Icons/QQMusic.ico", UriKind.Relative));
                        MainTitle.Text = "QQ音乐播放器";
                        StartButton.Background = new SolidColorBrush(new Color() { R = 255, G = 220, B = 0, A = 255 });// #ffdc00 背景黄色
                        StartButton.Foreground = new SolidColorBrush(new Color() { R = 17, G = 190, B = 115, A = 255 });// #11be73 文字绿色
                        break;
                    }
                case 1:
                    {
                        // #fd2b56
                        MainTitleIcon.Source = new BitmapImage(new System.Uri("/Resources/Icons/CloudMusic.ico", UriKind.Relative));
                        MainTitle.Text = "网易云音乐播放器";
                        StartButton.Background = new SolidColorBrush(new Color() { R = 253, G = 43, B = 86, A = 255 });// #fd2b56 背景红色
                        break;
                    }
            }
        }

        // 主页提示语
        private string tip = "\u2190  “音乐” 中可设置歌曲，“设置”中可选择启动平台";

        // 定义计时器
        private MainTimer mainTimer = new();

        // 更新页面
        public void UpdatePageAfterStartMusic()
        {
            StartButton.Content = "启动";
            CountDownTextBlock.Text = tip;
        }

        // 点击开始按钮
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (StaticData.IsStartButtonClick)
            {
                mainTimer.CloseTimer();

                // 状态更新
                StaticData.IsStartButtonClick = false;
                StartButton.Content = "启动";
                CountDownTextBlock.Text = tip;

                // 通知
                new ToastContentBuilder()
                    .AddArgument("action", "viewConversation")
                    .AddArgument("conversationId", 9813)
                    .AddText("已取消倒计时播放")
                    .AddText($"已取消计划在 {StaticData.WillBeginHour}:{StaticData.WillBeginMinute} 播放 \"{StaticData.WillBeginMusic}\"")
                    .Show();

                return;
            }

            // 如果列表中没有歌曲
            if (StaticData.MusicDataList[0] == "")
            {
                MessageBox.Show("请在 音乐 中添加至少一首音乐");
                return;
            }

            // 储存即将播放的音乐
            StaticData.WillBeginMusic = StaticData.MusicDataList[0];
            // 储存即将播放的时间
            StaticData.WillBeginHour = StaticData.BeginHour;
            StaticData.WillBeginMinute = StaticData.BeginMinute;

            mainTimer.SetTimer();

            // 按钮显示取消
            StartButton.Content = "取消";

            // 保存按钮状态
            StaticData.IsStartButtonClick = true;

            // 调整主页显示状态
            CountDownTextBlock.Text = $"即将在 {StaticData.WillBeginHour}:{StaticData.WillBeginMinute} 播放 \"{StaticData.WillBeginMusic}\"";

            // 通知
            new ToastContentBuilder()
                .AddArgument("action", "viewConversation")
                .AddArgument("conversationId", 9813)
                .AddText("已启动倒计时播放")
                .AddText($"即将在 {StaticData.WillBeginHour}:{StaticData.WillBeginMinute} 播放 \"{StaticData.WillBeginMusic}\"")
                .Show();
        }
    }
}