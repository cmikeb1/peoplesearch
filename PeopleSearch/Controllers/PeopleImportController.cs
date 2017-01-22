using PeopleSearch.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PeopleSearch.Controllers
{
    public class PeopleImportController : Controller
    {
        PeopleImportService peopleImportService = new PeopleImportService();

        // GET: PeopleImport
        public ActionResult Index()
        {
            ViewBag.Title = "PeopleImport";
            ViewBag.PeopleCount = peopleImportService.PeopleCount();

            return View();
        }

        // GET: PeopleImport/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PeopleImport/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PeopleImport/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PeopleImport/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PeopleImport/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PeopleImport/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PeopleImport/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
