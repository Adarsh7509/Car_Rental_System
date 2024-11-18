using Car_Rental_System.Models;
using Car_Rental_System.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car_Rental_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarSpecificationsController : ControllerBase
    {
        private readonly ICarSpecificationService _service;
        public CarSpecificationsController(ICarSpecificationService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<CarSpecification> carSpecifications = _service.GetAllCarSpecifications();
            return Ok(carSpecifications);
        }

        [HttpGet("{id}")]
        public IActionResult GetCarById(int id)
        {
            CarSpecification carSpecification = _service.GetCarSpecificationById(id);
            return Ok(carSpecification);
        }

        [HttpPost]
        public IActionResult Post(CarSpecification carSpecification)
        {
            int Result = _service.AddNewCarSpecification(carSpecification);
            return Ok(Result);
        }

        [HttpPut]
        public IActionResult Put(CarSpecification carSpecification)
        {
            string result = _service.UpdateCarSpecification(carSpecification);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            string result = _service.DeleteCarSpecification(id);
            return Ok(result);
        }
    }
}