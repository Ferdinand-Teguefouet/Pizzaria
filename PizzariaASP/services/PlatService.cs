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
        private readonly IFileService _fiservice;
        private readonly ICategorieService _catService;

        public PlatService(PizzariaContext dc, IWebHostEnvironment env, IFileService fiservice, ICategorieService catService)
        {
            _dc = dc;
            _env = env;
            _fiservice = fiservice;
            _catService = catService;
        }

        public void Add(PlatAddModel form)
        {
            string fileName = null;
            // Création du fichier dans le dossier uploads qui se trouve dans wwwroot
            if (form.File != null)
            {
                fileName = _fiservice.AddFile(file: form.File);
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
                Categories = _catService.GetAll()
            };
            return pAModel;
        }

        public Plat Delete(int id)
        {
            // Récupérer le plat dont l'id est celui passé en paramètre
            Plat toDelete = _dc.Plats.Find(id);

            if (toDelete == null)
            {
                return null;
            }
            _dc.Plats.Remove(toDelete);
            _dc.SaveChanges();
            return toDelete;
        }

        public PlatCategorieModel GetAll([FromQuery] int? filter)
        {
            PlatCategorieModel pCModel = new PlatCategorieModel
            {
                Filtre = filter,
                Plats = GetAllPlats(filter),

                Categories = _catService.GetAll()
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
            DeleteFile(toUpdate.Image);
            toUpdate.Image = _fiservice.AddFile(form.File);
            _dc.SaveChanges();
            return true;
        }

        public IEnumerable<PlatModel> GetAllPlats([FromQuery] int? filter)
        {
            return _dc.Plats
                         .Where(p => p.CategorieId == filter || filter == null)
                         .Select(p => new PlatModel
                         {
                             Id = p.Id,
                             Nom = p.Nom,
                             prix = p.Prix,
                             Image = p.Image,
                             CategorieNom = p.Categorie.Nom
                         });
        }

        public void DeleteFile(string image)
        {
            if (image != null)
            {
                File.Delete(Path.Combine(_env.WebRootPath, "uploads", image)); // _env.WebRootPath trouve automatiquement le dossier uploads et le combine avec le nom de l'image
            }
        }
    }
}
