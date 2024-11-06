namespace 午休网易云播放器
{
    public static class StaticData
    {
        public static void SetStaticData()
        {
            GetData();
            GetMusicListData();
        }

        // 获取其他数据
        public static void GetData()
        {
            BeginHour = Settings.Default.BeginHour;
            BeginMinute = Settings.Default.BeginMinute;

            LateTime = Settings.Default.LateTime;
        }


        // 音乐列表数据
        public static List<String> MusicDataList = new();
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



        public static string AppName = "午休网易云播放器";

        public static int BeginHour;
        public static int BeginMinute;

        public static string TestMusicName = "";

        //开启循环按钮状态
        public static bool IsStartButtonClick = false;

        //延迟时间
        public static int LateTime;
    }
}
