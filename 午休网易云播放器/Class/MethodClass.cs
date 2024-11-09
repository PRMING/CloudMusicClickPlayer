using System.Runtime.InteropServices;
using WindowsInput;
using WindowsInput.Native;

namespace 午休网易云播放器.Class
{
    public class MethodClass
    {
        // 开始点击
        public void TaskStartMusic(string musicName, int lateTime)
        {
            // 导入 SetCursorPos 函数
            [DllImport("user32.dll")]
            static extern bool SetCursorPos(int X, int Y);

            InputSimulator inputSimulator = new();

            inputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LWIN, VirtualKeyCode.VK_R);
            Thread.Sleep(lateTime + 500);

            inputSimulator.Keyboard.TextEntry("cmd");
            Thread.Sleep(lateTime + 50);
            inputSimulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            Thread.Sleep(lateTime + 1000);

            inputSimulator.Keyboard.TextEntry("start C:\\ProgramData\\Microsoft\\Windows\\\"Start Menu\"\\Programs\\网易云音乐.lnk");
            inputSimulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            inputSimulator.Keyboard.TextEntry("exit");
            inputSimulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            Thread.Sleep(lateTime + 5000);

            Thread.Sleep(lateTime + 500);
            inputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LWIN, VirtualKeyCode.UP);

            Thread.Sleep(lateTime + 500);

            // 模拟鼠标移动到屏幕坐标 (405, 36)
            SetCursorPos(405, 36);
            Thread.Sleep(lateTime + 200);

            inputSimulator.Mouse.LeftButtonClick();

            // 清空输入内容
            inputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_A);
            Thread.Sleep(lateTime + 200);
            inputSimulator.Keyboard.KeyPress(VirtualKeyCode.BACK);
            Thread.Sleep(lateTime + 200);
            // 输入内容
            inputSimulator.Keyboard.TextEntry(musicName);
            Thread.Sleep(lateTime + 200);
            // 回车搜索
            inputSimulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            Thread.Sleep(lateTime + 500);
            // 空白区点击
            SetCursorPos(873, 34);
            inputSimulator.Mouse.LeftButtonClick();

            Thread.Sleep(lateTime + 1000);

            // 单曲点击
            SetCursorPos(387, 152);

            inputSimulator.Mouse.LeftButtonClick();
            Thread.Sleep(lateTime + 300);

            // 音乐播放点击
            SetCursorPos(370, 260);
            Thread.Sleep(lateTime + 1000);
            inputSimulator.Mouse.LeftButtonClick();
            Thread.Sleep(400);
            inputSimulator.Mouse.LeftButtonClick();

            Thread.Sleep(lateTime + 1000);

            // 打开歌词界面
            SetCursorPos(57, 1003);
            inputSimulator.Mouse.LeftButtonClick();
            Thread.Sleep(lateTime + 500);
            inputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_D);
        }

        /// <summary>
        /// 音乐排序
        /// </summary>
        public void MusicSort()
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
            StaticData.SaveMusicListDataToSettings();
        }
    }
}