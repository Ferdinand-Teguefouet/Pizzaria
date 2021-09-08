using PizzariaASP.Models;
using PizzariaDAL;
using PizzariaDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaASP.services
{
    public class CategorieService : ICategorieService
    {
        private readonly PizzariaContext _dc;

        public CategorieService(PizzariaContext dc)
        {
            _dc = dc;
        }

        public void Add(CategorieAddModel form)
        {
            // transformer CategorieAddModel => Categorie
            Categorie c = new Categorie { Nom = form.Nom };
            // enregistrer les données
            _dc.categories.Add(c);
            _dc.SaveChanges();
        }

        public bool Delete(int id)
        {
            // Récupérer la catégorie dont l'id est celui passé en paramètre
            Categorie toDelete = _dc.categories.Find(id);
            if (toDelete == null)
            {
                return false;
            }
            _dc.categories.Remove(toDelete);
            _dc.SaveChanges();
            return false;
        }

        public IEnumerable<CategorieModel> GatAll()
        {
            return _dc.categories.Select(c => new CategorieModel
            {
                Id = c.Id,
                Nom = c.Nom
            });
        }

        public bool Update(int id,CategorieUpdateModel form)
        {
            Categorie toUpdate = _dc.categories.Find(id);
            if (toUpdate == null)
            {
                return false;
            }
                toUpdate.Nom = form.Nom;
                _dc.SaveChanges();
            return true;
        }

        public CategorieUpdateModel GetOne(int id)
        {
            // Récupérer l'objet dont l'id est celui passé en paramètre
            Categorie toUpdate = _dc.categories.Find(id);
            CategorieUpdateModel model = new CategorieUpdateModel
            {
                Nom = toUpdate.Nom
            };
            return model;
        }
    }
}
