using Microsoft.AspNetCore.Mvc;
using PizzariaASP.Models;
using PizzariaASP.services;
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
        private readonly ICategorieService _categorieService;

        public CategorieController(ICategorieService service)
        {
            _categorieService = service;
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

            return View(_categorieService.GatAll());
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
                _categorieService.Add(form);
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
            if (_categorieService.Delete(id))
            {
                return NotFound();
            }
                TempData["success"] = $"La catégorie a été supprimée!";
                return RedirectToAction("Index");
        }

        public IActionResult update(int id)
        {
            CategorieUpdateModel model = _categorieService.GetOne(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(int id, CategorieUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                _categorieService.Update(id, model);
                TempData["success"] = $"La mise à jour a bien eu lieu!";
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
