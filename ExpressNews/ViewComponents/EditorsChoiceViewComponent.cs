using ExpressNews.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpressNews.ViewComponents
{
    public class EditorsChoiceViewComponent : ViewComponent
    {
        private readonly IArticleService _articleService;
        public EditorsChoiceViewComponent(IArticleService articleService)
        {
            _articleService = articleService;
        }
       
        public IViewComponentResult Invoke(string count)
        {
            var intcount = int.Parse(count);
            var result = _articleService.EditorsChoiceArticles(intcount);
            return View(result);
        }
    }
}
