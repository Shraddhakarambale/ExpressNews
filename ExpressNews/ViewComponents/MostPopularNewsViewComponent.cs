using ExpressNews.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpressNews.ViewComponents
{
    public class MostPopularNewsViewComponent : ViewComponent
    {
        private readonly IArticleService _articleService;
        public MostPopularNewsViewComponent(IArticleService articleService)
        {
            _articleService = articleService;
        }
        public IViewComponentResult Invoke(string count)
        {
            var intcount = int.Parse(count);
            var result = _articleService.GetPopularArticles(intcount);
            return View(result);
        }

    }
}
