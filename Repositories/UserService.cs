using Car_Rental_System.Models;

namespace Car_Rental_System.Repositories
{
    public class UserService : IUserService
    {
        private Car_Rental_SystemContext _context;
        public UserService(Car_Rental_SystemContext context)
        {
            _context = context;
        }

        public List<User> GetAllUser()
        {

            var users = _context.Users.ToList();
            if (users.Count > 0)
            { return users; }
            else
                return null;
        }

        public int AddNewUser(User user)
        {
            try
            {
                if (user != null)
                {
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    return user.UserId;
                }
                else return 0;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public string DeleteUser(int id)
        {
            if (id != null)
            {
                var user = _context.Users.FirstOrDefault(x => x.UserId == id);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                    return "the given user id is " + id + " " + "Removed";
                }
                else
                    return "Something went wrong with deletion";

            }
            return "Id should not be null or zero";
        }

        public User GetUserById(int id)
        {
            if (id != 0 || id != null)
            {
                var user = _context.Users.FirstOrDefault(x => x.UserId == id);
                if (user != null)
                    return user;
                else
                    return null;
            }
            return null;
        }

        public string UpdateUser(User user)
        {
            var existingUser = _context.Users.FirstOrDefault(x => x.UserId == user.UserId);
            if (existingUser != null)
            {

                existingUser.UserId = user.UserId;
                existingUser.LastName = user.LastName;
                existingUser.Email = user.Email;
                existingUser.PasswordHash = user.PasswordHash;
                existingUser.PhoneNumber = user.PhoneNumber;
                existingUser.CreatedAt = user.CreatedAt;
                existingUser.LastLogin = user.LastLogin;
                existingUser.PaymentDetails = user.PaymentDetails;

                _context.Entry(existingUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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