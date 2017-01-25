using System;
using System.Web.Mvc;

namespace PeopleSearch.Controllers
{
    public class JasmineController : Controller
    {
        public ViewResult Run()
        {
            return View("SpecRunner");
        }
    }
}
