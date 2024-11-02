using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TareaClinicaProgra4.Models;
using TareaClinicaProgra4.Service;


namespace TareaClinicaProgra4.Controllers
{
    public class VirusController : Controller
    {
        private Services sv;

        public VirusController()
        {
            sv = new Services();
        }
        // GET: VirusController
        public ActionResult Index()
        {
            var model = sv.MostrarViruses();
            return View(model);
        }

        // GET: VirusController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VirusController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Virus model)
        {
            try
            {
                if (ModelState.IsValid) { 
                    sv.AgregarVirus(model);
                    return RedirectToAction(nameof(Index));
                }   
            }
            catch
            {
               
            }

            return View();
        }


        // GET: VirusController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var model = sv.BuscarVirus(id);
                sv.EliminarVirus(model);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return View();
        }

    }
}
