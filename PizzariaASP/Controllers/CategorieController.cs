using Microsoft.AspNetCore.Mvc;
using PizzariaASP.Models;
using PizzariaDAL;
using PizzariaDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaASP.Controllers
{
    public class CategorieController : Controller
    {
        private readonly PizzariaContext _dc;

        public CategorieController(PizzariaContext dc)
        {
            _dc = dc;
        }

        public IActionResult Index()
        {
            //// Transformer la liste de catégorie en liste de "categorieModel"
            //IEnumerable<Categorie> cat =  _dc.categories;
            //// => IEnumerable<CategorieModel>
            //List<CategorieModel> model = new List<CategorieModel>();
            //foreach (Categorie c in cat)
            //{
            //    model.Add(new Categorie {
            //         Id = c.Id,
            //         Nom = c.Nom
            //    });
            //}
            //return View();

            return View(_dc.categories.Select(c => new CategorieModel { 
                Id = c.Id,
                Nom = c.Nom
            }));
        }

        // afficher le formulaire
        public IActionResult Create()
        {
            return View();
        }

        // traiter le formulaire
        [HttpPost]
        public IActionResult Create(CategorieAddModel form)
        {
           bool valid = ModelState.IsValid; //Propriété des contrôleurs qui vérifie la validité du formulaire

            // si le formulaire est valide
            if (valid)
            {
                // transformer CategorieAddModel => Categorie
                Categorie c = new Categorie { Nom = form.Nom };                
                // enregistrer les données
                _dc.categories.Add(c);
                _dc.SaveChanges();
                // popup enregistrement Ok

                // permet d'envoyer des messages à la vue, mais ces messages sont perdus après une redirection
                //ViewBag.Key = "value"; // Objet dont les propriétés sont construites dynamiquement
                //ViewData["Key"] = "value";
                // tempdata est un dictionnaire qui transmet des données à la vue même après une redirection
                TempData["success"] = "Enregistrement effectué!";
                // Rediriger vers la page d'index
                return RedirectToAction("Index");
            }


            // sinon
            // message d'erreur
            return View(form);
        }

        public IActionResult Delete(int id)
        {
            // Récupérer la catégorie dont l'id est celui passé en paramètre
            Categorie toDelete = _dc.categories.Find(id);
            if (toDelete == null)
            {
                return NotFound();
            }
                _dc.categories.Remove(toDelete);
                _dc.SaveChanges();
                TempData["success"] = $"La catégorie {toDelete.Nom} a été supprimée!";
                return RedirectToAction("Index");
        }

        public IActionResult update(int id)
        {
            // Récupérer l'objet dont l'id est celui passé en paramètre
            Categorie toUpdate = _dc.categories.Find(id);
            CategorieUpdateModel model = new CategorieUpdateModel
            {
                Nom = toUpdate.Nom
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(int id, CategorieUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                Categorie toUpdate = _dc.categories.Find(id);
                toUpdate.Nom = model.Nom;
                _dc.SaveChanges();
                TempData["success"] = $"La mise à jour a bien eu lieu!";
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
