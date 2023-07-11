using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using U_HaulWebAppMVC.Models;

namespace U_HaulWebAppMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IUsersService _usersService;

        public HomeController(ILogger<HomeController> logger, IConfiguration Configuration, IUsersService usersService)
        {
            _logger = logger;
            _configuration = Configuration;
            _usersService = usersService;
        }

        public IActionResult Index(bool active = false)
        {
            List<User> users = new List<User>();
            if (active)
            {
                users = _usersService.GetActiveUsers();
            }
            else
            {
                users = _usersService.GetAllUsers();
            }
            return View(users);
        }

        public IActionResult AllUsers()
        {
            List<User> users = _usersService.GetAllUsers();
            return View(users);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}