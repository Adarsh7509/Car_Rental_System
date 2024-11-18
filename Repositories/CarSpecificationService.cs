using Car_Rental_System.Models;

namespace Car_Rental_System.Repositories
{
    public class CarSpecificationService : ICarSpecificationService
    {
        private Car_Rental_SystemContext _context;
        public CarSpecificationService(Car_Rental_SystemContext context)
        {
            _context = context;
        }

        public List<CarSpecification> GetAllCarSpecifications()
        {

            var carSpecifications = _context.CarSpecifications.ToList();
            if (carSpecifications.Count > 0)
            { return carSpecifications; }
            else
                return null;
        }

        public int AddNewCarSpecification(CarSpecification carSpecification)
        {
            try
            {
                if (carSpecification != null)
                {
                    _context.CarSpecifications.Add(carSpecification);
                    _context.SaveChanges();
                    return carSpecification.CarId;
                }
                else return 0;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public string DeleteCarSpecification(int id)
        {
            if (id != null)
            {
                var carSpecification = _context.CarSpecifications.FirstOrDefault(x => x.CarId == id);
                if (carSpecification != null)
                {
                    _context.CarSpecifications.Remove(carSpecification);
                    _context.SaveChanges();
                    return "the given CarSpecification id " + id + " Removed";
                }
                else
                    return "Something went wrong with deletion";

            }
            return "Id should not be null or zero";
        }

        public CarSpecification GetCarSpecificationById(int id)
        {
            if (id != 0 || id != null)
            {
                var carSpecification = _context.CarSpecifications.FirstOrDefault(x => x.CarId == id);
                if (carSpecification != null)
                    return carSpecification;
                else
                    return null;
            }
            return null;
        }

        public string UpdateCarSpecification(CarSpecification carSpecification)
        {
            var existingCar = _context.CarSpecifications.FirstOrDefault(x => x.CarId == carSpecification.CarId);
            if (existingCar != null)
            {
                existingCar.SpecificationId = carSpecification.SpecificationId;
                existingCar.Specification = carSpecification.Specification;
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