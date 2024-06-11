using ExpressNews.Migrations;
using ExpressNews.Models.Database;
using ExpressNews.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpressNews.Controllers
{
    public class TipController : Controller
    {
        private readonly ITipService _tipService;
        private readonly IConfiguration _configuration;
        public TipController(ITipService tipService, IConfiguration configuration)
        {
            _tipService = tipService;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View(_tipService.GetTips());
        }
        public IActionResult Edit(int id) 
        {
            var tip = _tipService.GetTipById(id);

            return View(tip);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Tip tip)
        {
            if (tip.FormImages.Count > 0)
            {
                _tipService.UploadFilesToContainer(tip);
            }
            _tipService.UpdateTip(tip);
            return RedirectToAction("Index");
        }


        public IActionResult Create() 
        { 
            return View(); 
        }
        [HttpPost]
        public IActionResult Create(Tip tips) 
        {
            if (ModelState.IsValid)
            {
                if (tips.FormImages.Count > 0)
                {
                    _tipService.UploadFilesToContainer(tips);
                }
                _tipService.AddTip(tips);
               
           
            }
            return RedirectToAction("Index");

        }
        public IActionResult Details(int id)
        {
            try
            {
                var tip = _tipService.GetTipDetails(id);
                return View(tip);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        public IActionResult Delete(int id)
        {
            try
            {
                var tip = _tipService.GetTipDetails(id);
                return View(tip);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _tipService.DeleteTip(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }


        }

    }
}
