using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Toolkit.Uwp.Notifications;
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
            
            // 设置当前页面
            StaticData.StartPage = "SettingPage";

            // 时间显示
            HourTextBlock.Text = $"{StaticData.BeginHour}";
            MinuteTextBlock.Text = $"{StaticData.BeginMinute}";

            // 延迟时间显示
            LateTimeTextBox.Text = $"{StaticData.LateTime}";

            // 快捷测试歌曲显示
            FastTestMusicNameTextBox.Text = StaticData.TestMusicName;

            // 目录显示路径以及 悬浮
            LocalDataFileTextBlock.Text = $"C:\\Users\\{Environment.UserName}\\AppData\\Local\\午休网易云播放器";
            LocalDataFileTextBlock.ToolTip = $"C:\\Users\\{Environment.UserName}\\AppData\\Local\\午休网易云播放器";
            
            // 下拉框选择音乐播放方法显示
            StartMusicMethodTypeComboBox.SelectedIndex = StaticData.StartMusicMethodType;
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
        private async void BeginMusicButton_Click(object sender, RoutedEventArgs e)
        {
            string beginMusicName = "快捷测试";
            if (StaticData.TestMusicName != "")
            {
                beginMusicName = StaticData.TestMusicName;
            }
            
            MethodClass methodClass = new();
            
            // 选择播放平台
            switch (StaticData.StartMusicMethodType)
            {
                case 0:
                    await methodClass.TaskStartQQMusic(beginMusicName, StaticData.LateTime);
                    break;
                case 1:
                    await methodClass.TaskStartCloudMusic(beginMusicName, StaticData.LateTime);
                    break;
            }
            
            // 通知
            new ToastContentBuilder()
                .AddArgument("action", "viewConversation")
                .AddArgument("conversationId", 9813)
                .AddText("已完成测试")
                .AddText($"已完成播放 {beginMusicName} 歌曲的测试")
                .Show();
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

        // 打开目录按钮
        private void OpenLocalDataFileButtonClick(object sender, RoutedEventArgs e)
        {
            //打开目录
            System.Diagnostics.Process.Start( "explorer.exe" , $"C:\\Users\\{Environment.UserName}\\AppData\\Local\\午休网易云播放器" );
        }

        // 清除数据按钮
        private void RemoveLocalData(object sender, RoutedEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo($"C:\\Users\\{Environment.UserName}\\AppData\\Local\\午休网易云播放器");
            
            // 获取并删除所有文件
            FileInfo[] files = di.GetFiles();
            foreach (FileInfo file in files) {
                file.Delete();
            }
            // 获取并删除所有目录
            DirectoryInfo[] subDirectories = di.GetDirectories();
            foreach (DirectoryInfo subDirectory in subDirectories) {
                subDirectory.Delete(true);
            }
        }

        // 下拉框选择音乐播放方法
        private void StartMusicMethodType(object sender, RoutedEventArgs e)
        {
            // 保存状态
            StaticData.StartMusicMethodType = StartMusicMethodTypeComboBox.SelectedIndex;
            Settings.Default.StartMusicMethodType = StartMusicMethodTypeComboBox.SelectedIndex;
            Settings.Default.Save();
                
            // 显示提示框
            switch (StartMusicMethodTypeComboBox.SelectedIndex)
            {
                case 0: MessageBox.Show("已设置QQ音乐播放");
                    break;
                case 1: MessageBox.Show("已设置网易云音乐播放");
                    break;
            }
        }
    }
}