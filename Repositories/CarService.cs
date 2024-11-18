using Car_Rental_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental_System.Repositories
{
    public class CarService : ICarService
    {
        private Car_Rental_SystemContext _context;
        public CarService(Car_Rental_SystemContext context)
        {
            _context = context;
        }

        public List<Car> GetAllCars()
        {

            var cars = _context.Cars.ToList();
            if (cars.Count > 0)
            { return cars; }
            else
                return null;
        }

        public int AddNewCar(Car car)
        {
            try
            {
                if (car != null)
                {
                    _context.Cars.Add(car);
                    _context.SaveChanges();
                    return car.CarId;
                }
                else return 0;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public string DeleteCar(int id)
        {
            if (id != null)
            {
                var car = _context.Cars.FirstOrDefault(x => x.CarId == id);
                if (car != null)
                {
                    _context.Cars.Remove(car);
                    _context.SaveChanges();
                    return "the given Car id " + id + " Removed";
                }
                else
                    return "Something went wrong with deletion";

            }
            return "Id should not be null or zero";
        }

        public Car GetCarById(int id)
        {
            if (id != 0 || id != null)
            {
                var car = _context.Cars.FirstOrDefault(x => x.CarId == id);
                if (car != null)
                    return car;
                else
                    return null;
            }
            return null;
        }

        public string UpdateCar(Car car)
        {
            var existingCar = _context.Cars.FirstOrDefault(x => x.CarId == car.CarId);
            if (existingCar != null)
            {
                existingCar.Make = car.Make;
                existingCar.Model = car.Model;
                existingCar.Year = car.Year;
                existingCar.Location = car.Location;
                existingCar.PricePerDay = car.PricePerDay;
                existingCar.AvailabilityStatus = car.AvailabilityStatus;
                _context.Entry(existingCar).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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