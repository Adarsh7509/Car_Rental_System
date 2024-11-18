using Car_Rental_System.Models;

namespace Car_Rental_System.Repositories
{
    public interface IPaymentService
    {
    
            public List<Payment> GetAllPayment();
            public Payment GetPaymentById(int id);
            public int AddNewPayment(Payment payment);
            public string UpdatePayment(Payment payment);
            public string DeletePayment(int id);
        }
    }


