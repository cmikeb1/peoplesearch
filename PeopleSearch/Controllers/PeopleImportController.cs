using PeopleSearch.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace PeopleSearch.Controllers
{
    public class PeopleImportController : Controller
    {
        PeopleImportService peopleImportService = new PeopleImportService();

        private int MAX_SINGLE_IMPORT = 500;

        public PeopleImportController() : base()
        {
            this.peopleImportService = new PeopleImportService();
        }

        public PeopleImportController(PeopleImportService peopleImportService)
        {
            this.peopleImportService = peopleImportService;
        }

        // GET: PeopleImport
        public ActionResult Index()
        {
            ViewBag.Title = "PeopleImport";
            return View();
        }

        // POST: PeopleImport/Import
        [HttpPost]
        public ActionResult Import(FormCollection collection)
        {
            try
            {
                int importCount = Int32.Parse(collection.Get("importCount"));

                if(importCount > MAX_SINGLE_IMPORT || importCount < 1)
                {
                    throw new ArgumentOutOfRangeException("importCount", String.Format("You must import between 1 and {0} people.", MAX_SINGLE_IMPORT));
                }

                var newPeople = peopleImportService.ImportPeople(importCount);

                return Json(newPeople);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception caught: {0}", ex);
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { message = ex.Message });
            }
        }

        // POST: PeopleImport/Import
        [HttpPost]
        public ActionResult Purge()
        {
            try
            {
                int purgedCount = peopleImportService.Purge();

                return Json(new { message = String.Format("{0} people have been purged", purgedCount) });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught: {0}", ex);
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { message = ex.Message });
            }
        }
    }
}
