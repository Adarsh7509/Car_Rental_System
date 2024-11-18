using Car_Rental_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental_System.Repositories
{
    public class AdminService: IAdminService
    {
        private Car_Rental_SystemContext _context;
            public AdminService(Car_Rental_SystemContext context)
            {
                _context = context;
            }

            public List<Admin> GetAllAdmin()
            {

                var admins = _context.Admins.ToList();
                if (admins.Count > 0)
                { return admins; }
                else
                    return null;
            }

            public int AddNewAdmin(Admin admin)
            {
                try
                {
                    if (admin != null)
                    {
                        _context.Admins.Add(admin);
                        _context.SaveChanges();
                        return admin.AdminId;
                    }
                    else return 0;
                }
                catch (Exception e)
                {

                    throw new Exception(e.Message);
                }
            }

            public string DeleteAdmin(int id)
            {
                if (id != null)
                {
                    var admin = _context.Admins.FirstOrDefault(x => x.AdminId == id);
                    if (admin != null)
                    {
                        _context.Admins.Remove(admin);
                        _context.SaveChanges();
                        return "the given Admin id is " + id +" "+ "Removed";
                    }
                    else
                        return "Something went wrong with deletion";

                }
                return "Id should not be null or zero";
            }

            public Admin GetAdminById(int id)
            {
                if (id != 0 || id != null)
                {
                    var admin = _context.Admins.FirstOrDefault(x => x.AdminId == id);
                    if (admin != null)
                        return admin;
                    else
                        return null;
                }
                return null;
            }

            public string UpdateAdmin(Admin admin)
            {
                var existingAdmin = _context.Admins.FirstOrDefault(x => x.AdminId == admin.AdminId);
                if (existingAdmin != null)
                {

                existingAdmin.AdminId = admin.AdminId;
                existingAdmin.Username = admin.Username;
                existingAdmin.PasswordHash = admin.PasswordHash;
                existingAdmin.Role = admin.Role;
              
                    _context.Entry(existingAdmin).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

