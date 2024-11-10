using System.Timers;
using Microsoft.Toolkit.Uwp.Notifications;
using Timer = System.Timers.Timer;

namespace 午休网易云播放器.Class;

public class MainTimer
{
    private Timer? _aTimer;

    // 当前时间
    private DateTime _nowTime;

    public void SetTimer()
    {
        // Create a timer with a two-second interval.
        _aTimer = new System.Timers.Timer(1000);
        // Hook up the Elapsed event for the timer.
        _aTimer.Elapsed += OnTimedEvent;
        _aTimer.AutoReset = true;
        _aTimer.Enabled = true;
    }

    /// <summary>
    /// 关闭 Timer
    /// </summary>
    public void CloseTimer()
    {
        _aTimer?.Stop();
        // 释放内存
        _aTimer?.Dispose();
    }

    /// <summary>
    /// Timer 执行事件
    /// </summary>
    private void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        Task.Run(async () =>
        {
            _nowTime = DateTime.Now;

            if (_nowTime.Hour == StaticData.WillBeginHour && _nowTime.Minute == StaticData.WillBeginMinute)
            {
                // 通知
                new ToastContentBuilder()
                    .AddArgument("action", "viewConversation")
                    .AddArgument("conversationId", 9813)
                    .AddText("开始播放音乐")
                    .AddText($"已开始播放 {StaticData.WillBeginMusic} 歌曲")
                    .Show();
                
                // 关闭计时器
                CloseTimer();

                MethodClass methodClass = new();

                // 选择播放平台
                switch (StaticData.StartMusicMethodType)
                {
                    case 0: 
                        await methodClass.TaskStartQQMusic(StaticData.WillBeginMusic, StaticData.LateTime);
                        break;
                    case 1: 
                        await methodClass.TaskStartCloudMusic(StaticData.WillBeginMusic, StaticData.LateTime);
                        break;
                }

                // 删除音乐
                StaticData.MusicDataList[0] = "";

                // 音乐排序
                methodClass.MusicListSort();

                // 切换状态
                // StaticData.IsStartButtonClick = false;

                // 切换HomePage状态
                //HomePage homePage = new();
                //HomePageController pageController = new HomePageController(homePage);
                //pageController.UpdatePageAfterStartMusic();

                // 退出程序
                Environment.Exit(0);
            }
        });
    }
}