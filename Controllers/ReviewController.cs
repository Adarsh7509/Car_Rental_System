using Car_Rental_System.Models;
using Car_Rental_System.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car_Rental_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _service;
        public ReviewsController(IReviewService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Review> reviews = _service.GetAllReviews();
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public IActionResult GetCarById(int id)
        {
            Review review = _service.GetReviewById(id);
            return Ok(review);
        }

        [HttpPost]
        public IActionResult Post(Review review)
        {
            int Result = _service.AddNewReview(review);
            return Ok(Result);
        }

        [HttpPut]
        public IActionResult Put(Review review)
        {
            string result = _service.UpdateReview(review);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            string result = _service.DeleteReview(id);
            return Ok(result);
        }
    }
}