using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarWashSystem.DTO
{
    public class UserUpdatedto
    {
        [Required(ErrorMessage = " Name is required")]
        [DisplayName(" Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]

        public string Password { get; set; }
        public string Address { get; set; }
    }
}
