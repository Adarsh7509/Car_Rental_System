using Car_Rental_System.Models;

namespace Car_Rental_System.Repositories
{
    public class CarImageService : ICarImageService
    {
             private Car_Rental_SystemContext _context;
            public CarImageService(Car_Rental_SystemContext context)
            {
                _context = context;
            }

            public List<CarImage> GetAllCarImage()
            {

                var carImage = _context.CarImages.ToList();
                if (carImage.Count > 0)
                { return carImage; }
                else
                    return null;
            }

            public int AddNewCarImage(CarImage carImage)
            {
                try
                {
                    if (carImage != null)
                    {
                        _context.CarImages.Add(carImage);
                        _context.SaveChanges();
                        return carImage.ImageId;
                    }
                    else return 0;
                }
                catch (Exception e)
                {

                Console.WriteLine(e.InnerException?.Message); // Check for inner exception details
                throw;
            }
            }

            public string DeleteCarImage(int id)
            {
                if (id != null)
                {
                    var carImage = _context.CarImages.FirstOrDefault(x => x.ImageId == id);
                    if (carImage != null)
                    {
                        _context.CarImages.Remove(carImage);
                        _context.SaveChanges();
                        return "the given CarImage id is " + id + " " + "Removed";
                    }
                    else
                        return "Something went wrong with deletion";

                }
                return "Id should not be null or zero";
            }

            public CarImage GetCarImageById(int id)
            {
                if (id != 0 || id != null)
                {
                    var carImage = _context.CarImages.FirstOrDefault(x => x.ImageId  == id);
                    if (carImage != null)
                        return carImage;
                    else
                        return null;
                }
                return null;
            }

            public string UpdateCarImage(CarImage carImage)
            {
                var existingCarImage = _context.CarImages.FirstOrDefault(x => x.ImageId == carImage.ImageId);
                if (existingCarImage != null)
                {

                existingCarImage.ImageId = carImage.ImageId;
                existingCarImage.CarId = carImage.CarId;
                existingCarImage.ImageUrl = carImage.ImageUrl;
                    
                 _context.Entry(existingCarImage).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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



