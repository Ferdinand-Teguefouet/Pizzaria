using Microsoft.AspNetCore.Mvc;
using PizzariaASP.Models;
using PizzariaDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaASP.services
{
    public interface IPlatService
    {
        IEnumerable<PlatModel> GetAllPlats([FromQuery] int? filter);
        PlatCategorieModel GetAll([FromQuery] int? filter);

        PlatUpdateModel GetOne(int id);

        PlatAddModel GetAllCategorie();

        void Add(PlatAddModel form);

        bool Update(int id, PlatUpdateModel form);

        Plat Delete(int id);
        void DeleteFile(string image);
    }
}
