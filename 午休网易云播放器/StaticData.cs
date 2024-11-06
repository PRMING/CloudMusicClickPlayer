namespace 午休网易云播放器
{
    public static class StaticData
    {
        public static void GetDataFromSetting()
        {
            BeginHour = Settings.Default.BeginHour;
            BeginMinute = Settings.Default.BeginMinute;

            LateTime = Settings.Default.LateTime;
        }

        public static string AppName = "午休网易云播放器";

        public static int BeginHour;
        public static int BeginMinute;

        public static string MusicName = "";

        //开启循环按钮状态
        public static bool IsStartButtonClick = false;

        //延迟时间
        public static int LateTime;


    }
}
