using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaASP.Models
{
    public class CategorieAddModel
    {
        [Required] // pour dire que le champ est obligatoire
        [MaxLength(50)] // pour la longueur maximale
        public string Nom { get; set; }
    }
}
