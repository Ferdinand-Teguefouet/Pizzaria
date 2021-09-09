using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzariaDAL.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; } // en string parce que l'on ne fait pas des opérations sur un numéro de téléphone,
                                              // en plus si on met un type nombre les chiffres "00" ne seront pas affichés
        public string password { get; set; } // en byte dans le but de crypter
        public string Role { get; set; }
        public Guid Salt { get; set; }
        public IEnumerable<Commande> Commandes { get; set; }
    }
}
