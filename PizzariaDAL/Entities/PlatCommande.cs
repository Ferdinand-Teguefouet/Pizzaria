using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzariaDAL.Entities
{
    public class PlatCommande
    {
        public int Id { get; set; }
        public int PlatId { get; set; }
        public int CommandId { get; set; }
        public decimal Prix { get; set; }
        public Plat Plat { get; set; }
        public Commande commande { get; set; }
    }
}
