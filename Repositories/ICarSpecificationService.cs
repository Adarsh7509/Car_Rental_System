using Car_Rental_System.Models;

namespace Car_Rental_System.Repositories
{
    public interface ICarSpecificationService
    {
        List<CarSpecification> GetAllCarSpecifications();
        CarSpecification GetCarSpecificationById(int id);
        int AddNewCarSpecification(CarSpecification department);
        string UpdateCarSpecification(CarSpecification department);
        string DeleteCarSpecification(int id);
    }
}