using System.Timers;
using System.Windows.Threading;
using 午休网易云播放器.PageControllers;
using 午休网易云播放器.Pages;
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
        Task.Run(() =>
        {
            _nowTime = DateTime.Now;

            if (_nowTime.Hour == StaticData.WillBeginHour && _nowTime.Minute == StaticData.WillBeginMinute)
            {
                // 关闭计时器
                CloseTimer();

                MethodClass methodClass = new();
                methodClass.TaskStartMusic(StaticData.WillBeginMusic, StaticData.LateTime);

                // 删除音乐
                StaticData.MusicDataList[0] = "";

                // 音乐排序
                methodClass.MusicSort();

                // 切换状态
                StaticData.IsStartButtonClick = false;

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