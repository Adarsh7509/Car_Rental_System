using Car_Rental_System.Models;

namespace Car_Rental_System.Repositories
{
    public interface IAdminService
    {
        List<Admin> GetAllAdmin();
        Admin GetAdminById(int id);
        int AddNewAdmin(Admin admin);
        string UpdateAdmin(Admin admin);
        string DeleteAdmin(int id);
    }
}
