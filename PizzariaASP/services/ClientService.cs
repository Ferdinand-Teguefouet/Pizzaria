using PizzariaASP.Models;
using PizzariaDAL;
using PizzariaDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaASP.services
{
    public class ClientService : IClientService
    {
        private readonly PizzariaContext _dc;

        public ClientService(PizzariaContext dc)
        {
            _dc = dc;
        }

        public void Create(RegisterModel form, Guid salt, string hashed)
        {
            Client toSave = new Client
            {
                Nom = form.Nom,
                Email = form.Email,
                Telephone = form.Tel,
                Salt = salt,
                password = hashed,
                Role = "Customer"
            };
            _dc.Clients.Add(toSave);
            _dc.SaveChanges();
        }

        public Client GetByEmail(string email)
        {
            return _dc.Clients.SingleOrDefault(c => c.Email == email);
        }
    }
}
