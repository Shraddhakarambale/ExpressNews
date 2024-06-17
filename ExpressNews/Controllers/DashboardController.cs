﻿using ExpressNews.Models.ViewModel;
using ExpressNews.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpressNews.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IUserInterface _userService;
        private readonly IArticleService _articleService;
        private readonly ISubscriptionService _subscriptionService;
        private readonly IConfiguration _configuration;

        public DashboardController(IUserInterface userService, IConfiguration configuration,IArticleService articleService,ISubscriptionService subscriptionService)
        {
            _userService = userService;
            _configuration = configuration;
            _articleService = articleService;
            _subscriptionService = subscriptionService;


        }
        public IActionResult Index()

        
        {
            ViewBag.MemberCount = _userService.GetMemberCount();
            ViewBag.JournalistCount = _userService.GetJournalistCount();
            ViewBag.EditorCount = _userService.GetEditorCount();
            ViewBag.SubscribedCount = _articleService.GetSubscribedMemberCount();
            ViewBag.NonSubscribedCount = _articleService.GetNonSubscribedMemberCount();
            ViewBag.bascicCount = _subscriptionService.GetBasicCount();
            ViewBag.premiumCount= _subscriptionService.GetPremiumCount();
            var totaluserCount = _subscriptionService.GetTotalUserCount();
            var subscribedCount = _subscriptionService.GetBasicCount();
            //ViewBag.nonSubscribedCount = totaluserCount - subscribedCount;

            return View();

        }
        public IActionResult SubsriptionChart()
        {
            return View();

        }
            
    }
}
