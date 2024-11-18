using Car_Rental_System.Models;
using Car_Rental_System.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car_Rental_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _service;
            public ReservationController(IReservationService service)
            {
                _service = service;
            }

            [HttpGet]
            public IActionResult GetAll()
            {
                List<Reservation> reservations = _service.GetAllReservation();
                return Ok(reservations);
            }

            [HttpGet("{id}")]
            public IActionResult GetReservationById(int id)
            {
            Reservation reservation = _service.GetReservationById(id);
                return Ok(reservation);
            }

            [HttpPost]
            public IActionResult Post(Reservation reservation)
            {
                int Result = _service.AddNewReservation(reservation);
                return Ok(Result);
            }

            [HttpPut]
            public IActionResult Put(Reservation reservation)
            {
                string result = _service.UpdateReservation(reservation);
                return Ok(result);
            }

            [HttpDelete]
            public IActionResult Delete(int id)
            {
                string result = _service.DeleteReservation(id);
                return Ok(result);
            }
        }
    }

