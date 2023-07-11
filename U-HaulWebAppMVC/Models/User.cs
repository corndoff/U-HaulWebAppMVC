using System.ComponentModel.DataAnnotations;

namespace U_HaulWebAppMVC.Models
{
    public class User
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UniqueLoginName { get; set; }
    }
}
