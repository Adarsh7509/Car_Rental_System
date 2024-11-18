using Car_Rental_System.Models;

namespace Car_Rental_System.Repositories
{
    public class PaymentService : IPaymentService
    {
        private Car_Rental_SystemContext _context;
            public PaymentService(Car_Rental_SystemContext context)
            {
                _context = context;
            }

            public List<Payment> GetAllPayment()
            {

                var payment = _context.Payments.ToList();
                if (payment.Count > 0)
                { return payment; }
                else
                    return null;
            }

            public int AddNewPayment(Payment payment)
            {
                try
                {
                    if (payment != null)
                    {
                        _context.Payments.Add(payment);
                        _context.SaveChanges();
                        return payment.PaymentId;
                    }
                    else return 0;
                }
                catch (Exception e)
                {

                    throw new Exception(e.Message);
                }
            }

            public string DeletePayment(int id)
            {
                if (id != null)
                {
                    var payment = _context.Payments.FirstOrDefault(x => x.PaymentId == id);
                    if (payment != null)
                    {
                        _context.Payments.Remove(payment);
                        _context.SaveChanges();
                        return "the given Payment id is " + id + " " + "Removed";
                    }
                    else
                        return "Something went wrong with deletion";

                }
                return "Id should not be null or zero";
            }

            public Payment GetPaymentById(int id)
            {
                if (id != 0 || id != null)
                {
                    var payment = _context.Payments.FirstOrDefault(x => x.PaymentId == id);
                    if (payment != null)
                        return payment;
                    else
                        return null;
                }
                return null;
            }

            public string UpdatePayment(Payment? payment)
            {
                var existingPayment = _context.Payments.FirstOrDefault(x => x.PaymentId == payment.PaymentId);
                if (existingPayment != null)
                {
                existingPayment.PaymentId = payment.PaymentId;
                existingPayment.ReservationId = payment.ReservationId;
                existingPayment.Amount = payment.Amount;
                existingPayment.PaymentDate = payment.PaymentDate;
                existingPayment.PaymentMethod = payment.PaymentMethod;
                existingPayment.PaymentStatus = payment.PaymentStatus;     


                    _context.Entry(existingPayment).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                    return "Record Updated successfully";
                }
                else
                {
                    return "something went wrong while update";
                }
           
        }
        
    }
    }





