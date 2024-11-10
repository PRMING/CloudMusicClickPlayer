using System.Windows;
using System.Windows.Controls;
using 午休网易云播放器.Class;

namespace 午休网易云播放器.Pages
{
    /// <summary>
    /// AboutPage.xaml 的交互逻辑
    /// </summary>
    public partial class AboutPage : Page
    {
        public AboutPage()
        {
            InitializeComponent();
            
            // 设置当前页面
            StaticData.StartPage = "AboutPage";

            TitleTextBlock.Text = $"关于 \"{StaticData.AppName}\"";

            string developMode;

#if DEBUG
            developMode = "开发版";
#else
            developMode = "正式版";
#endif

            VersionTextBlock.Text = $"版本：{Application.ResourceAssembly.GetName().Version.ToString()} {developMode}";
        }
    }
}