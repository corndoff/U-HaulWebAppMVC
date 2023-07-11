using System.Data.SqlClient;
using U_HaulWebAppMVC.Models;

namespace U_HaulWebAppMVC
{
    public class UsersService : IUsersService
    {
        private readonly ILogger<UsersService> _logger;
        private readonly IConfiguration _configuration;
        public UsersService(ILogger<UsersService> logger, IConfiguration Configuration)
        {
            _logger = logger;
            _configuration = Configuration;
        }
        public List<User> GetAllUsers()
        {
            string constr = _configuration.GetConnectionString("SqlServer");
            List<User> users = new List<User>();

            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "SELECT * FROM Users";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                users.Add(new User
                                {
                                    FirstName = sdr["first_name"].ToString(),
                                    LastName = sdr["last_name"].ToString(),
                                    UniqueLoginName = sdr["unique_login_name"].ToString()
                                });
                            }
                        }
                    }
                }
                _logger.Log(LogLevel.Information, "GetAllUsers called");
            }
            catch (Exception e) 
            {
                _logger.LogError(e, e.Message);
                throw;
            }
            return users;
        }

        public List<User> GetActiveUsers()
{
            string constr = _configuration.GetConnectionString("SqlServer");
            List<User> users = new List<User>();

            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "SELECT * FROM Users WHERE IsActive = 1";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                users.Add(new User
                                {
                                    FirstName = sdr["first_name"].ToString(),
                                    LastName = sdr["last_name"].ToString(),
                                    UniqueLoginName = sdr["unique_login_name"].ToString()
                                });
                            }
                        }
                    }
                }
                _logger.Log(LogLevel.Information, "GetActiveUsers called");
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }
            return users;
        }
    }
}

