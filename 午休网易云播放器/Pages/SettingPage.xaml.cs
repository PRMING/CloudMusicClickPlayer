using System.Windows;
using System.Windows.Controls;
using 午休网易云播放器;

namespace 午休网易云播放器.Pages
{
    /// <summary>
    /// SettingPage.xaml 的交互逻辑
    /// </summary>
    public partial class SettingPage : Page
    {
        public SettingPage()
        {
            InitializeComponent();

            // 显示数据
            HourTextBlock.Text = $"{StaticData.BeginHour}";
            MinuteTextBlock.Text = $"{StaticData.BeginMinute}";
            LateTimeTextBox.Text = $"{StaticData.LateTime}";

            MusicNameTextBox.Text = StaticData.MusicName;
        }

        // 设置时间按钮
        private void SetStartTimeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(MinuteTextBlock.Text) > 59 || Convert.ToInt32(MinuteTextBlock.Text) < 0)
                {
                    MessageBox.Show("请输入正确时间！");
                    return;
                }
                if (Convert.ToInt32(HourTextBlock.Text) > 23 || Convert.ToInt32(HourTextBlock.Text) < 0)
                {
                    MessageBox.Show("请输入正确时间！");
                    return;
                }
                else
                {
                    StaticData.BeginHour = Convert.ToInt32(HourTextBlock.Text);
                    Settings.Default.BeginHour = Convert.ToInt32(HourTextBlock.Text);

                    StaticData.BeginMinute = Convert.ToInt32(MinuteTextBlock.Text);
                    Settings.Default.BeginMinute = Convert.ToInt32(MinuteTextBlock.Text);

                    Settings.Default.Save();

                    MessageBox.Show($"播放时间 {StaticData.BeginHour}:{StaticData.BeginMinute} 设置成功！");
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show("请输入正确时间！");
            }

        }

        // 设置音乐名称
        private void SetMusicNameButton_Click(object sender, RoutedEventArgs e)
        {
            if (MusicNameTextBox.Text == "")
            {
                MessageBox.Show("请输入歌曲名称");
                return;
            }

            StaticData.MusicName = MusicNameTextBox.Text;
            MessageBox.Show($"音乐 {StaticData.MusicName} 设置成功！");
        }

        // 快捷测试
        private void BeginMusicButton_Click(object sender, RoutedEventArgs e)
        {
            MethodClass methodClass = new();
            methodClass.TaskStartMusic("测试", StaticData.LateTime);

            Environment.Exit(0);
        }

        private void LateTimeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(LateTimeTextBox.Text) < 0)
                {
                    MessageBox.Show("请输入正确延迟时间（毫秒）");
                }
                else
                {
                    StaticData.LateTime = Convert.ToInt32(LateTimeTextBox.Text);
                    Settings.Default.LateTime = Convert.ToInt32(LateTimeTextBox.Text);
                    Settings.Default.Save();

                    MessageBox.Show($"延迟 {StaticData.LateTime} 毫秒设置成功！");
                }
                
            }
            catch (System.FormatException)
            {
                MessageBox.Show("请输入正确延迟时间（毫秒）");
            }
        }
    }
}
