using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaASP.Models
{
    public class PlatAddModel
    {
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [MaxLength(50)]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [RegularExpression(@"[0-9]{1,6}([.,][0-9]{0,2})?")]
        public string Prix { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [MaxLength(300)]
        public string Description { get; set; }

        public int CategorieId { get; set; }

        public IFormFile File { get; set; }
        public IEnumerable<CategorieModel> Categories{ get; set; }
    }
}
