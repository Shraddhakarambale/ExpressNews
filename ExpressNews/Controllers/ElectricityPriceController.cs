using ExpressNews.Models.ViewModel;
using ExpressNews.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

namespace ExpressNews.Controllers
{
    public class ElectricityPriceController : Controller
    {
        private readonly IElectricityDataService _electricityDataService;
        public ElectricityPriceController(IElectricityDataService electricityDataService)
        {
            _electricityDataService = electricityDataService;
        }
        public async Task<IActionResult> Index()
        {
            DateTime strDate = DateTime.Now;
            int yr = strDate.Year;
            int mn = strDate.Month;
            int dy = strDate.Day;

            string month = mn.ToString();
            string day = dy.ToString();

            if (mn<10)
                month = "0" + mn;

            if (dy < 10)
                day = "0" + dy;

            string fulldate = yr + month + day;

            var data = await _electricityDataService.GetSpotPricesAsync("SE3", fulldate);

            List<ElectricityVM> electricityVMList = new List<ElectricityVM>();
            foreach (var item in data)
            {
                var viewModel = new ElectricityVM
                {
                    Timestamp = item.RowKey.Substring(8),
                    Price = (item.Price/ 100),
                    PartitionKey = item.PartitionKey
                };
                electricityVMList.Add(viewModel);
            }
                       
            ViewBag.Date = DateTime.Now.ToString("yyyy-MM-dd");
            
            return View(electricityVMList);
        }
    }
}
