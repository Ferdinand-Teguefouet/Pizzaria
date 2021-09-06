using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzariaDAL.Entities
{
    public class Plat
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public decimal Prix { get; set; } // avec decimal on a moin de problème
        public string Description { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public Categorie Categorie { get; set; }
        public IEnumerable<PlatCommande> platCommandes { get; set; }
    }
}
