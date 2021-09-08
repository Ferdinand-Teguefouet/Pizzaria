using PizzariaASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaASP.services
{
    public interface ICategorieService
    {
        IEnumerable<CategorieModel> GatAll();

        CategorieUpdateModel GetOne(int id);

        void Add(CategorieAddModel form);

        bool Update(int id, CategorieUpdateModel form);

        bool Delete(int id);
    }
}
