using Car_Rental_System.Models;
using Car_Rental_System.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car_Rental_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<User> users = _service.GetAllUser();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetAdminById(int id)
        {
            User user = _service.GetUserById(id);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            int Result = _service.AddNewUser(user);
            return Ok(Result);
        }

        [HttpPut]
        public IActionResult Put(User user)
        {
            string result = _service.UpdateUser(user);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            string result = _service.DeleteUser(id);
            return Ok(result);
        }
    }
}