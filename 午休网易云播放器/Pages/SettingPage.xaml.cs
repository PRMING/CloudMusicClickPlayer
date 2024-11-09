using System.Windows;
using System.Windows.Controls;
using 午休网易云播放器.Class;

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

            // 时间显示
            HourTextBlock.Text = $"{StaticData.BeginHour}";
            MinuteTextBlock.Text = $"{StaticData.BeginMinute}";

            // 延迟时间显示
            LateTimeTextBox.Text = $"{StaticData.LateTime}";

            // 快捷测试歌曲显示
            FastTestMusicNameTextBox.Text = StaticData.TestMusicName;
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

        // 设置快捷测试音乐名称
        private void SetMusicNameButton_Click(object sender, RoutedEventArgs e)
        {
            if (FastTestMusicNameTextBox.Text == "")
            {
                MessageBox.Show("请输入快捷测试音乐名称");
                return;
            }

            StaticData.TestMusicName = FastTestMusicNameTextBox.Text;
            MessageBox.Show($"快捷测试音乐 {StaticData.TestMusicName} 设置成功");
        }

        // 快捷测试
        private void BeginMusicButton_Click(object sender, RoutedEventArgs e)
        {
            string beginMusicName = "快捷测试";
            if (StaticData.TestMusicName != "")
            {
                beginMusicName = StaticData.TestMusicName;
            }
            MethodClass methodClass = new();
            methodClass.TaskStartMusic(beginMusicName, StaticData.LateTime);

            Environment.Exit(0);
        }

        // 延时按钮
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