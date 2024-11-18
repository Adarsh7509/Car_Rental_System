using Car_Rental_System.Models;
using Car_Rental_System.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car_Rental_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _service;
        public CarsController(ICarService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Car> cars = _service.GetAllCars();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public IActionResult GetCarById(int id)
        {
            Car car = _service.GetCarById(id);
            return Ok(car);
        }

        [HttpPost]
        public IActionResult Post(Car car)
        {
            int Result = _service.AddNewCar(car);
            return Ok(Result);
        }

        [HttpPut]
        public IActionResult Put(Car car)
        {
            string result = _service.UpdateCar(car);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            string result = _service.DeleteCar(id);
            return Ok(result);
        }
    }
}