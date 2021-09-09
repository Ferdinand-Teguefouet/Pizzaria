using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzariaASP.Models;
using PizzariaASP.services;
using PizzariaDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaASP.Controllers
{
    public class SecurityController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IHashService _hashService;
        private readonly IMailService _mailService;

        public SecurityController(IClientService clientService, IHashService hashService, IMailService mailService)
        {
            _clientService = clientService;
            _hashService = hashService;
            _mailService = mailService;
        }

        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult login(LoginModel form)
        {
            //client = demander au ClientService.GetByEmail(form.Email)
            Client client = _clientService.GetByEmail(form.Email);
            // if(client == null) Tempdata["Error"] = "Error" return view()
            // else string password = hashService.Hash(form.PlainPassword)
            if (client == null || client.password != _hashService.Hash(form.PlainPassword, client.Salt.ToString()))
            {
                TempData["error"] = "Erreur mot de passe ou Email";
                return View(form);
            }            
            // if(client.Password == password) rediriger
            TempData["success"] = "Bienvenue" + client.Nom;
            HttpContext.Session.SetString("Role", client.Role);
            HttpContext.Session.SetInt32("Id", client.Id);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult register(RegisterModel form)
        {
            if (ModelState.IsValid)
            {
                Guid salt = Guid.NewGuid();
                string hashed = _hashService.Hash(form.Password, salt.ToString());
                _clientService.Create(form, salt, hashed);
                TempData["success"] = "Client crée";
                _mailService.SendEmail("Welcome", "Bienvenue à vous sur notre plateforme", form.Email);
                return this.RedirectToAction("Login");
            }
            return View(form);
        }
    }
}
