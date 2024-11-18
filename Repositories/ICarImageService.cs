using Car_Rental_System.Models;

namespace Car_Rental_System.Repositories
{
    public interface ICarImageService
    {
        List<CarImage> GetAllCarImage();
        CarImage GetCarImageById(int id);
        int AddNewCarImage(CarImage carImage);
        string UpdateCarImage(CarImage carImage);
        string DeleteCarImage(int id);
    }
}
