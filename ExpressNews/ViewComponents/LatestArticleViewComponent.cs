using ExpressNews.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpressNews.ViewComponents
{
    public class LatestArticleViewComponent: ViewComponent
    {
        private readonly IArticleService _articleService;
        public LatestArticleViewComponent(IArticleService articleService) 
        { 
            _articleService = articleService;
        }
        public IViewComponentResult Invoke(string count)
        {
            var intcount = int.Parse(count);
            var result = _articleService.GetLatestArticles(intcount);
            return View(result);
        }
    }
}
