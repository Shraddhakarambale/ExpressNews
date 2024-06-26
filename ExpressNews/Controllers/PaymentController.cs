using ExpressNews.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpressNews.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        
       public IActionResult Index(string type)
        {
            var result = _paymentService.GetSubcriptionTypeDetails(type);

           
            return View(result);
        }
    }
}
