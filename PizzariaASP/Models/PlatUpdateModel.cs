using Microsoft.AspNetCore.Http;
using Pizzeria.ASP.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaASP.Models
{
    public class PlatUpdateModel
    {
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [MaxLength(50)]
        public string Nom { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [RegularExpression(@"[0-9]{1,6}([.,][0-9]{0,2})?", ErrorMessage = "Le prix n'est pas correct. Maximum 2 chiffres après la virgule.")]
        public string Prix { get; set; }
        
        [MaxLength(300)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [FileMimeType("image/jpg", "image/jpeg", "image/png", "image/x-icon")]
        public IFormFile File { get; set; }
        public string Image { get; set; }
    }
}
