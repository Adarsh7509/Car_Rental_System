using Car_Rental_System.Models;

namespace Car_Rental_System.Repositories
{
    public interface IUserService
    {

        List<User> GetAllUser();
        User GetUserById(int id);
        int AddNewUser(User user);
        string UpdateUser(User user);
        string DeleteUser(int id);

    }
}