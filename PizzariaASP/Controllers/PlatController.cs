using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PizzariaASP.Models;
using PizzariaASP.services;
using PizzariaDAL;
using PizzariaDAL.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaASP.Controllers
{
    public class PlatController : Controller
    {
        private readonly IPlatService _platService;
        public PlatController(IPlatService service)
        {
            _platService = service;
        }
        public IActionResult Index([FromQuery] int? filtre) => View(_platService.GetAll(filtre));

        public IActionResult Create() => View(_platService.GetAllCategorie());

        [HttpPost]
        public IActionResult Create(PlatAddModel form)
        {
            if (ModelState.IsValid)
            {
                _platService.Add(form);
                TempData["success"] = "Enregistrement effectué!";
                // Rediriger vers la page d'index
                return RedirectToAction("Index");
            }
            return View(form);            
        }

        public IActionResult Delete(int id)
        {
            Plat p = _platService.Delete(id);
            if (p == null)
            {
                return NotFound();
            }
            _platService.DeleteFile(p.Image);
            TempData["success"] = $"Le plat et le fichier image ont été supprimés!";
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id) => View(_platService.GetOne(id));

        [HttpPost]
        public IActionResult Update(int id, PlatUpdateModel modelForm)
        {
            if (ModelState.IsValid)
            {
                if (!_platService.Update(id, modelForm))
                {
                    return NotFound();
                }
                TempData["success"] = $"La mise à jour a bien eu lieu!";
                return RedirectToAction("Index");
            }
            return View(modelForm);
        }
    }
}
