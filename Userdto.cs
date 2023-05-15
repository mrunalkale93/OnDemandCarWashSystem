﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CarWashSystem.DTO
{
    public class Userdto
    {

        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Full Name is required")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]

        public string Password { get; set; }
        public string Address { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }
    }
}
