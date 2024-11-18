using Car_Rental_System.Models;

namespace Car_Rental_System.Repositories
{
    public interface IReviewService
    {
        List<Review> GetAllReviews();
        Review GetReviewById(int id);
        int AddNewReview(Review review);
        string UpdateReview(Review review);
        string DeleteReview(int id);
    }
}