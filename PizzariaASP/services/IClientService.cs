using PizzariaASP.Models;
using PizzariaDAL.Entities;
using System;

namespace PizzariaASP.services
{
    public interface IClientService
    {
        Client GetByEmail(string email);
        void Create(RegisterModel form, Guid salt, string hashed);
    }
}