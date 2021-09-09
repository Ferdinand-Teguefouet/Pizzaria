using Microsoft.AspNetCore.Mvc;
using PizzariaASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaASP.services
{
    public interface IPlatService
    {
        PlatCategorieModel GetAll([FromQuery] int? filter);

        PlatUpdateModel GetOne(int id);

        PlatAddModel GetAllCategorie();

        void Add(PlatAddModel form);

        bool Update(int id, PlatUpdateModel form);

        bool Delete(int id);
    }
}
