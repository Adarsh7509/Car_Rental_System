using Car_Rental_System.Models;

namespace Car_Rental_System.Repositories
{
    public interface IReservationService
    {
            List<Reservation> GetAllReservation();
            Reservation GetReservationById(int id);
            int AddNewReservation(Reservation reservation);
            string UpdateReservation(Reservation reservation);
            string DeleteReservation(int id);
        
    }
}
