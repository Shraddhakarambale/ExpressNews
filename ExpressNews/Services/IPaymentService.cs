using ExpressNews.Models.ViewModel;

namespace ExpressNews.Services
{
    public interface IPaymentService
    {
        PaymentVM GetSubcriptionTypeDetails(string type);
    }
}
