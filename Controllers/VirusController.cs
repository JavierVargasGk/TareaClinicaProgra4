using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TareaClinicaProgra4.Controllers
{
    public class VirusController : Controller
    {
        // GET: VirusController
        public ActionResult Index()
        {
            return View();
        }

        // GET: VirusController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VirusController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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


        // GET: VirusController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

    }
}
