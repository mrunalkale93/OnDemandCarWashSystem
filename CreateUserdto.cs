using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CarWashSystem.DTO
{
    public class CreateUserdto
    {
        [Required(ErrorMessage = "Full Name is required")]
        [DisplayName("Full Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password is required")]


        public string Password { get; set; }
        public string Address { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }
    }
}
