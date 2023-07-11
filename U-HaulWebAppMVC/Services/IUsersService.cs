using U_HaulWebAppMVC.Models;

namespace U_HaulWebAppMVC
{
    public interface IUsersService
    {
        List<User> GetAllUsers();
        List<User> GetActiveUsers();
    }
}
