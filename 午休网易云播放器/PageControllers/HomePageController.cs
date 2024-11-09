using 午休网易云播放器.Pages;

namespace 午休网易云播放器.PageControllers
{
    public class HomePageController
    {
        private HomePage page;

        public HomePageController(HomePage page)
        {
            this.page = page;
        }

        // 方法用于更新Page中的Label内容
        public void UpdatePageAfterStartMusic()
        {
            // 调度到UI线程进行更新
            page.Dispatcher.Invoke(() =>
            {
                page.UpdatePageAfterStartMusic();
            });
        }
    }
}