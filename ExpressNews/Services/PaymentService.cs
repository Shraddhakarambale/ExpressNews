using ExpressNews.Data;
using ExpressNews.Models;
using ExpressNews.Models.ViewModel;

namespace ExpressNews.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PaymentService(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor) {
           _db = db;
            _httpContextAccessor = httpContextAccessor;
        }

        public PaymentVM GetSubcriptionTypeDetails(string type)
        {
            PaymentVM paymentVM = new PaymentVM();
            var result = _db.SubscriptionTypes.Where(a => a.TypeName == type).FirstOrDefault();

            var username = _httpContextAccessor.HttpContext.Session.GetString("UserName").ToString();
            var firstName = _httpContextAccessor.HttpContext.Session.GetString("UserFirstName").ToString(); 
            var lastName = _httpContextAccessor.HttpContext.Session.GetString("UserLastName").ToString();
            DateTime expiryDate = DateTime.Now;
            if (type == "BASIC")
            {
                expiryDate = DateTime.Now.AddMonths(6);
            }
            else
            {
                expiryDate = DateTime.Now.AddMonths(6);
            }
            paymentVM.Email = username;
            paymentVM.ExpirationDate = expiryDate;
            paymentVM.SubType = type;
            paymentVM.Amount = result.Price;
            paymentVM.Name = firstName + " " + lastName;    
            return paymentVM;
        }
    }
}
