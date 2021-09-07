using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaASP.Models
{
    public class CategorieAddModel
    {
        [Required(ErrorMessage = "Ce champ est requis")] // pour dire que le champ est obligatoire et ErrorMessage permet d'écraser le message d'erreur par défaut
        [MaxLength(50, ErrorMessage = "Le champ est trop long")] // pour la longueur maximale
        public string Nom { get; set; }
    }
}
