using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace CarWashSystem.Models
{
    public class UserDetails
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Full Name is required")]
        [DisplayName("Full Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Contact Number is required")]
        public long ContactNumber { get; set; }

        [Required(ErrorMessage = "Password is required")]

        public string Password { get; set; }
        public string CompleteAddress { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }

        [JsonIgnore]
        public IEnumerable<Payment> Payments { get; set; }

        [JsonIgnore]
        public IEnumerable<Car> Cars { get; set; }

        [JsonIgnore]
        public IEnumerable<OrderDetails> Order { get; set; }
    }
}
