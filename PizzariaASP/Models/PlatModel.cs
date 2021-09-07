using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaASP.Models
{
    public class PlatModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public decimal prix { get; set; }
        public string Description { get; set; }
        public string CategorieNom { get; set; }
    }
}
