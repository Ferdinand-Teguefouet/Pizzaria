using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzariaDAL.Entities
{
    public class Commande
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Statut { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
