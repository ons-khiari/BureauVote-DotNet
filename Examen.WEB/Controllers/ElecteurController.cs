using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using Examen.Infrastructure;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examen.WEB.Controllers
{
    public class ElecteurController : Controller
    {
        IService<Electeur> electeurService;

        public ElecteurController( IService<Electeur> electeurService)
        {
            this.electeurService=electeurService;
        }


        // GET: ElecteurController
        public ActionResult Index()
        {
            return View(electeurService.GetAll());
        }

        [HttpPost]
        public ActionResult Index(string cin) {
            return View(cin == null ? electeurService.GetAll() : electeurService.GetMany(e => e.CIN == cin));
        }
        // GET: ElecteurController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ElecteurController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ElecteurController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Electeur electeur)
        {
            if (!ModelState.IsValid)
            {
                // Log the validation errors for debugging
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return View(electeur);
            }

            try
            {
                electeurService.Add(electeur);
                electeurService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Log the exception details for debugging
                Console.WriteLine(ex.Message);
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                return View(electeur);
            }
        }

        // GET: ElecteurController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ElecteurController/Edit/5
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

        // GET: ElecteurController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(electeurService.GetById(id)) ;
        }

        // POST: ElecteurController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Electeur electeur)
        {
            try
            {
                electeur.ElecteurId = id;
                electeurService.Delete(electeur);
                electeurService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
