using Car_Rental_System.Models;

namespace Car_Rental_System.Repositories
{
    public class ReviewService : IReviewService
    {
        private Car_Rental_SystemContext _context;
        public ReviewService(Car_Rental_SystemContext context)
        {
            _context = context;
        }

        public List<Review> GetAllReviews()
        {

            var reviews = _context.Reviews.ToList();
            if (reviews.Count > 0)
            { return reviews; }
            else
                return null;
        }

        public int AddNewReview(Review review)
        {
            try
            {
                if (review != null)
                {
                    _context.Reviews.Add(review);
                    _context.SaveChanges();
                    return review.ReviewId;
                }
                else return 0;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public string DeleteReview(int id)
        {
            if (id != null)
            {
                var review = _context.Reviews.FirstOrDefault(x => x.ReviewId == id);
                if (review != null)
                {
                    _context.Reviews.Remove(review);
                    _context.SaveChanges();
                    return "the given Review id " + id + " Removed";
                }
                else
                    return "Something went wrong with deletion";

            }
            return "Id should not be null or zero";
        }

        public Review GetReviewById(int id)
        {
            if (id != 0 || id != null)
            {
                var review = _context.Reviews.FirstOrDefault(x => x.ReviewId == id);
                if (review != null)
                    return review;
                else
                    return null;
            }
            return null;
        }

        public string UpdateReview(Review review)
        {
            var existingReview = _context.Reviews.FirstOrDefault(x => x.ReviewId == review.ReviewId);
            if (existingReview != null)
            {
                existingReview.UserId = review.UserId;
                existingReview.CarId = review.CarId;
                existingReview.Rating = review.Rating;
                existingReview.ReviewText = review.ReviewText;
                existingReview.ReviewDate = review.ReviewDate;
                _context.Entry(existingReview).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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