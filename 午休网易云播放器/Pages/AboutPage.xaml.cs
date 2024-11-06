using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
