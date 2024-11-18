using Car_Rental_System.Models;

namespace Car_Rental_System.Repositories
{
    public class ReservationService: IReservationService
    {
      
            private Car_Rental_SystemContext _context;
            public ReservationService(Car_Rental_SystemContext context)
            {
                _context = context;
            }

            public List<Reservation> GetAllReservation()
            {

                var reservations = _context.Reservations.ToList();
                if (reservations.Count > 0)
                { return reservations; }
                else
                    return null;
            }

            public int AddNewReservation(Reservation reservation)
            {
                try
                {
                    if (reservation != null)
                    {
                        _context.Reservations.Add(reservation);
                        _context.SaveChanges();
                        return reservation.ReservationId;
                    }
                    else return 0;
                }
                catch (Exception e)
                {

                    throw new Exception(e.Message);
                }
            }

            public string DeleteReservation(int id)
            {
                if (id != null)
                {
                    var reservation = _context.Reservations.FirstOrDefault(x => x.ReservationId == id);
                    if (reservation != null)
                    {
                        _context.Reservations.Remove(reservation);
                        _context.SaveChanges();
                        return "the given Reservation id is " + id + " " + "Removed";
                    }
                    else
                        return "Something went wrong with deletion";

                }
                return "Id should not be null or zero";
            }

            public Reservation GetReservationById(int id)
            {
                if (id != 0 || id != null)
                {
                    var reservation = _context.Reservations.FirstOrDefault(x => x.ReservationId == id);
                    if (reservation != null)
                        return reservation;
                    else
                        return null;
                }
                return null;
            }

            public string UpdateReservation(Reservation reservation)
            {
                var existingreservation = _context.Reservations.FirstOrDefault(x => x.ReservationId == reservation.ReservationId);
                if (existingreservation != null)
                {


                existingreservation.ReservationId = reservation.ReservationId;
                existingreservation.Status = reservation.Status;
                existingreservation.CarId = reservation.CarId;
                existingreservation.PickupDate = reservation.PickupDate;
                existingreservation.DropoffDate = reservation.DropoffDate;
                existingreservation.UserId = reservation.UserId;
                existingreservation.TotalPrice = reservation.TotalPrice;

                     


                 _context.Entry(existingreservation).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

