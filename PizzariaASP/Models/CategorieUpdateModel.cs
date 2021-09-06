using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaASP.Models
{
    public class CategorieUpdateModel
    {
        [Required]
        [MaxLength(50)]
        public string Nom { get; set; }
    }
}
