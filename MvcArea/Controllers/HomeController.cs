using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcArea.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QuienesSomos()
        {
            return View();
        }

        public ActionResult Servicios()
        {
            return View();
        }

        public ActionResult Contactanos()
        {
            return View();
        }

        

    }
}
