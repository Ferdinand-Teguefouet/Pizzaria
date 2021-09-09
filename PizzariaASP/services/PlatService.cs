using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PizzariaASP.Models;
using PizzariaDAL;
using PizzariaDAL.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaASP.services
{
    public class PlatService : IPlatService
    {
        private readonly PizzariaContext _dc;
        private readonly IWebHostEnvironment _env;

        public PlatService(PizzariaContext dc, IWebHostEnvironment env)
        {
            _dc = dc;
            _env = env;
        }

        public void Add(PlatAddModel form)
        {
            string fileName = null;
            // Création du fichier dans le dossier uploads qui se trouve dans wwwroot
            if (form.File != null)
            {
                fileName = Guid.NewGuid() + form.File.FileName;
                string path = Path.Combine(_env.WebRootPath, "uploads");
                using FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
                form.File.CopyTo(stream);
            }
            Plat plat = new Plat
            {
                Nom = form.Nom,
                Prix = decimal.Parse(form.Prix.Replace('.', ',')),
                Description = form.Description,
                CategorieId = form.CategorieId,
                Image = fileName
            };

            _dc.Plats.Add(plat);
            _dc.SaveChanges();
        }

        public PlatAddModel GetAllCategorie()
        {
            PlatAddModel pAModel = new PlatAddModel
            {
                Categories = _dc.categories.Select(c => new CategorieModel
                {
                    Id = c.Id,
                    Nom = c.Nom
                })
            };
            return pAModel;
        }

        public bool Delete(int id)
        {
            // Récupérer le plat dont l'id est celui passé en paramètre
            Plat toDelete = _dc.Plats.Find(id);

            if (toDelete == null)
            {
                return false;
            }
            _dc.Plats.Remove(toDelete);
            _dc.SaveChanges();
            if (toDelete.Image != null)
            {
                File.Delete(Path.Combine(_env.WebRootPath, "uploads", toDelete.Image)); // _env.WebRootPath trouve automatiquement le dossier uploads et le combine avec le nom de l'image
            }
            return true;
        }

        public PlatCategorieModel GetAll([FromQuery] int? filter)
        {
            PlatCategorieModel pCModel = new PlatCategorieModel
            {
                Filtre = filter,
                Plats = _dc.Plats
                        .Where(p => p.CategorieId == filter || filter == null)
                        .Select(p => new PlatModel
                        {
                            Id = p.Id,
                            Nom = p.Nom,
                            prix = p.Prix,
                            Image = p.Image,
                            CategorieNom = p.Categorie.Nom
                        }),

                Categories = _dc.categories

                .Select(c => new CategorieModel
                {
                    Id = c.Id,
                    Nom = c.Nom
                })
            };
            return pCModel;
        }

        public PlatUpdateModel GetOne(int id)
        {
            // Récupérer l'objet dont l'id est celui passé en paramètre
            Plat toUpdate = _dc.Plats.Find(id);
            PlatUpdateModel platModel = new PlatUpdateModel
            {
                Nom = toUpdate.Nom,
                Prix = toUpdate.Prix.ToString(),
                Description = toUpdate.Description,
                Image = toUpdate.Image
            };
            return platModel;
        }

        public bool Update(int id, PlatUpdateModel form)
        {
            Plat toUpdate = _dc.Plats.Find(id);
            if (toUpdate == null)
            {
                return false;
            }
            toUpdate.Nom = form.Nom;
            toUpdate.Prix = decimal.Parse(form.Prix.Replace('.', ','));
            toUpdate.Description = form.Description;
            toUpdate.Image = form.Image;
            _dc.SaveChanges();
            return true;
        }
    }
}
