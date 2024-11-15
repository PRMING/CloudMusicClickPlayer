﻿namespace 午休音乐播放器.Class
{
    public static class StaticData
    {
        public static string AppName = "午休音乐播放器";

        public static int BeginHour;
        public static int BeginMinute;

        // 启动音乐方式
        public static int StartMusicMethodType;

        // 播放音乐点击时避免再次修改
        public static string WillBeginMusic = "";

        public static int WillBeginHour;
        public static int WillBeginMinute;

        public static string TestMusicName = "快捷测试";

        //开启循环按钮状态
        public static bool IsStartButtonClick = false;

        // 当前打开页面
        public static string StartPage = "HomePage";

        //延迟时间
        public static int LateTime;

        // 音乐列表数据
        public static List<string> MusicDataList = new();

        // 构造函数
        public static void SetStaticData()
        {
            GetData();
            GetMusicListData();
        }

        // 从本地获取数据
        private static void GetData()
        {
            BeginHour = Settings.Default.BeginHour;
            BeginMinute = Settings.Default.BeginMinute;
            LateTime = Settings.Default.LateTime;
            StartMusicMethodType = Settings.Default.StartMusicMethodType;
        }

        // 从Setting获取MusicListData
        public static void GetMusicListData()
        {
            MusicDataList.Add(Settings.Default.MusicName1);
            MusicDataList.Add(Settings.Default.MusicName2);
            MusicDataList.Add(Settings.Default.MusicName3);
            MusicDataList.Add(Settings.Default.MusicName4);
            MusicDataList.Add(Settings.Default.MusicName5);
            MusicDataList.Add(Settings.Default.MusicName6);
            MusicDataList.Add(Settings.Default.MusicName7);
        }

        // 将MusicListData保存到Settings
        public static void SaveMusicListDataToSettings()
        {
            Settings.Default.MusicName1 = MusicDataList[0];
            Settings.Default.MusicName2 = MusicDataList[1];
            Settings.Default.MusicName3 = MusicDataList[2];
            Settings.Default.MusicName4 = MusicDataList[3];
            Settings.Default.MusicName5 = MusicDataList[4];
            Settings.Default.MusicName6 = MusicDataList[5];
            Settings.Default.MusicName7 = MusicDataList[6];
            Settings.Default.Save();
        }
    }
}