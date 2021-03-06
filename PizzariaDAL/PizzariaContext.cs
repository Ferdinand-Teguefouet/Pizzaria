using Microsoft.EntityFrameworkCore;
using PizzariaDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzariaDAL
{
    public class PizzariaContext : DbContext
    {
        public DbSet<Plat> Plats { get; set; }
        public DbSet<Categorie> categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<PlatCommande> PlatCommandes { get; set; }

        public PizzariaContext(DbContextOptions options) : base(options)
        {
            
        }

    }
}
