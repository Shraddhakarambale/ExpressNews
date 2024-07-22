using ExpressNews.Models.ViewModel;
using ExpressNews.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Globalization;
using System.Text.RegularExpressions;
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
        public async Task<IActionResult> Index(string selectedRegion = "SE3")
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

            //var data = await _electricityDataService.GetSpotPricesAsync("SE3", fulldate);

            //List<ElectricityVM> electricityVMList = new List<ElectricityVM>();
            //foreach (var item in data)
            //{
            //    var viewModel = new ElectricityVM
            //    {
            //        Timestamp = item.RowKey.Substring(8),
            //        Prices = Convert.ToDecimal(item.Price) / 10000,
            //        PartitionKey = item.PartitionKey
            //    };
            //    electricityVMList.Add(viewModel);
            //}

            //ViewBag.Date = DateTime.Now.ToString("yyyy-MM-dd");

            //return View(electricityVMList);
            // Fetch data for all regions
            var se1Data = await _electricityDataService.GetSpotPricesAsync("SE1", fulldate);
            var se2Data = await _electricityDataService.GetSpotPricesAsync("SE2", fulldate);
            var se3Data = await _electricityDataService.GetSpotPricesAsync("SE3", fulldate);
            var se4Data = await _electricityDataService.GetSpotPricesAsync("SE4", fulldate);

            var viewModel = new ElectricityVM
            {
                Timestamp = se1Data.Select(item => item.RowKey.Substring(8)).Distinct().ToList(),
                SE3Prices = se3Data.OrderBy(item => item.RowKey).Select(item => Convert.ToDecimal(item.Price) / 100000).ToList(),
                SE1Prices = se1Data.OrderBy(item => item.RowKey).Select(item => Convert.ToDecimal(item.Price) / 100000).ToList(),
                SE2Prices = se2Data.OrderBy(item => item.RowKey).Select(item => Convert.ToDecimal(item.Price) / 100000).ToList(),
               
                SE4Prices = se4Data.OrderBy(item => item.RowKey).Select(item => Convert.ToDecimal(Regex.Replace(item.Price, @"\s", string.Empty)) / 100000).ToList(),
            };
            ViewBag.Date = DateTime.Now.ToString("yyyy-MM-dd");

            return View(viewModel);

        }
    }
}
