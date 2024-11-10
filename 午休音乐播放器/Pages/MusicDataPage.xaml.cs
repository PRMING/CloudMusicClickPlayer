using System.Windows;
using System.Windows.Controls;
using 午休音乐播放器.Class;

namespace 午休音乐播放器.Pages
{
    /// <summary>
    /// MusicDataPage.xaml 的交互逻辑
    /// </summary>
    public partial class MusicDataPage : Page
    {
        public MusicDataPage()
        {
            InitializeComponent();

            // 设置当前页面
            StaticData.StartPage = "MusicDataPage";

            SetTextBoxData();
        }

        // 读取数据
        private void SetTextBoxData()
        {
            MusicNameTextBox1.Text = StaticData.MusicDataList[0];
            MusicNameTextBox2.Text = StaticData.MusicDataList[1];
            MusicNameTextBox3.Text = StaticData.MusicDataList[2];
            MusicNameTextBox4.Text = StaticData.MusicDataList[3];
            MusicNameTextBox5.Text = StaticData.MusicDataList[4];
            MusicNameTextBox6.Text = StaticData.MusicDataList[5];
            MusicNameTextBox7.Text = StaticData.MusicDataList[6];
        }

        // 存储数据
        private void SetDataFromTextBoxToStaticData()
        {
            StaticData.MusicDataList[0] = MusicNameTextBox1.Text;

            StaticData.MusicDataList[1] = MusicNameTextBox2.Text;

            StaticData.MusicDataList[2] = MusicNameTextBox3.Text;

            StaticData.MusicDataList[3] = MusicNameTextBox4.Text;

            StaticData.MusicDataList[4] = MusicNameTextBox5.Text;

            StaticData.MusicDataList[5] = MusicNameTextBox6.Text;

            StaticData.MusicDataList[6] = MusicNameTextBox7.Text;

            Settings.Default.Save();
        }

        private void SaveMusicDataButton_Click(object sender, RoutedEventArgs e)
        {
            SetDataFromTextBoxToStaticData();

            // 判断是否全部为空
            bool isAllNull = true;
            for (int i = 0; i < StaticData.MusicDataList.Count; i++)
            {
                // 判断最后一项
                if (i == StaticData.MusicDataList.Count - 1)
                {
                    break;
                }
                if (StaticData.MusicDataList[i] == "")
                {
                    isAllNull = true;
                    continue;
                }
                isAllNull = false;
                break;
            }

            // 如果不是全部空则开始排序
            if (!isAllNull)
            {
                for (int i = 0; i < StaticData.MusicDataList.Count; i++)
                {
                    bool isNull = true;

                    // 判断此位最后
                    if (i == StaticData.MusicDataList.Count)
                    {
                        break;
                    }

                    // 此位非最后为空
                    if (StaticData.MusicDataList[i] == "")
                    {
                        // 后面全部向前移一位
                        for (int j = i; j < StaticData.MusicDataList.Count; j++)
                        {
                            // 如果此为为最后一位 等于空
                            if (j == StaticData.MusicDataList.Count - 1)
                            {
                                StaticData.MusicDataList[j] = "";
                                break;
                            }
                            // 此为非最后一位 等于后一位
                            StaticData.MusicDataList[j] = StaticData.MusicDataList[j + 1];
                        }

                        if (StaticData.MusicDataList[i] == "")
                        {
                            for (int j = i; j < StaticData.MusicDataList.Count; j++)
                            {
                                if (j == StaticData.MusicDataList.Count - 1)
                                {
                                    break;
                                }
                                if (StaticData.MusicDataList[j + 1] == "")
                                {
                                    isNull = true;
                                    continue;
                                }
                                isNull = false;
                                break;
                            }
                            if (isNull)
                            {
                                break;
                            }
                            i -= 1;
                        }
                    }
                }
                MessageBox.Show("保存成功");
            }
            else
            {
                MessageBox.Show("请至少输入一首歌");
            }
            StaticData.SaveMusicListDataToSettings();
        }
    }
}