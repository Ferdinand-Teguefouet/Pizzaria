using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaASP.Models
{
    public class RegisterModel
    {
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Tel { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
