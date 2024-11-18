using Car_Rental_System.Models;
using Car_Rental_System.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car_Rental_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImageController : ControllerBase
    {
        private readonly ICarImageService _service;
        public CarImageController(ICarImageService service)
        {
            _service = service;

        }
       
            [HttpGet]
            public IActionResult GetAll()
            {
                List<CarImage> carImages = _service.GetAllCarImage();
                return Ok(carImages);
            }

            [HttpGet("{id}")]
            public IActionResult GetAdminById(int id)
            {
            CarImage carImage = _service.GetCarImageById(id);
                return Ok(carImage);
            }

            [HttpPost]
            public IActionResult Post(CarImage carImage)
            {
                int Result = _service.AddNewCarImage(carImage);
                return Ok(Result);
            }

            [HttpPut]
            public IActionResult Put(CarImage carImage)
            {
                string result = _service.UpdateCarImage(carImage);
                return Ok(result);
            }

            [HttpDelete]
            public IActionResult Delete(int id)
            {
                string result = _service.DeleteCarImage(id);
                return Ok(result);
            }
        }
    }
