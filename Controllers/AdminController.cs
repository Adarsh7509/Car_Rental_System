using Car_Rental_System.Models;
using Car_Rental_System.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car_Rental_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
       private readonly IAdminService _service;
            public AdminController(IAdminService service)
            {
                _service = service;
            }

            [HttpGet]
            public IActionResult GetAll()
            {
                List<Admin> admins = _service.GetAllAdmin();
                return Ok(admins);
            }

            [HttpGet("{id}")]
            public IActionResult GetAdminById(int id)
            {
            Admin admin = _service.GetAdminById(id);
                return Ok(admin);
            }

            [HttpPost]
            public IActionResult Post(Admin admin)
            {
                int Result = _service.AddNewAdmin(admin);
                return Ok(Result);
            }

            [HttpPut]
            public IActionResult Put(Admin admin)
            {
                string result = _service.UpdateAdmin(admin);
                return Ok(result);
            }

            [HttpDelete]
            public IActionResult Delete(int id)
            {
                string result = _service.DeleteAdmin(id);
                return Ok(result);
            }
    }
}

