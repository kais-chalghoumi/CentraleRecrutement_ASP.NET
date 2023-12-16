using CentraleRecrutement.ApplicationCore.Domain;
using CentraleRecrutement.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentraleRecrutement.UI.Web.Controllers
{
    public class OffreController : Controller
    {
        IOffreService offreService;
        IServiceEntreprise entrepriseService;
        public OffreController(IOffreService os, IServiceEntreprise es)
        {
            offreService = os;
            entrepriseService= es;
        }
        // GET: OfffreController
        public ActionResult Index()
        {
            return View(offreService.GetAll());
        }

        [HttpPost]
        public ActionResult Index(string filtre)
        {
            var list = offreService.GetAll();
            if (!String.IsNullOrEmpty(filtre))
            {
                list = list.Where(m => m.Entreprise.AdresseEntreprise.Ville.ToString().Equals(filtre)).ToList();
            }
            return View(list);
        }

        // GET: OfffreController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OfffreController/Create
        public ActionResult Create()
        {
            var entreprises = entrepriseService.GetAll();
         
            ViewBag.Entreprise = new SelectList(entreprises, "IdEntreprise", "NomEntreprise");
            return View();
        }

        // POST: OfffreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Offre o)
        {
            try
            {
                offreService.Add(o);
                offreService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OfffreController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OfffreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OfffreController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OfffreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
