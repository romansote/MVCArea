using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcArea.Areas.Admincp.Controllers
{
    public class UbicacionController : Controller
    {
        private webdivEntities11 db = new webdivEntities11();

        //
        // GET: /Admincp/Ubicacion/

        public ActionResult Index()
        {
            return View(db.Ubicacion.ToList());
        }

        //
        // GET: /Admincp/Ubicacion/Details/5

        public ActionResult Details(int id = 0)
        {
            Ubicacion ubicacion = db.Ubicacion.Find(id);
            if (ubicacion == null)
            {
                return HttpNotFound();
            }
            return View(ubicacion);
        }

        //
        // GET: /Admincp/Ubicacion/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admincp/Ubicacion/Create

        [HttpPost]
        public ActionResult Create(Ubicacion ubicacion)
        {
            if (ModelState.IsValid)
            {
                db.Ubicacion.Add(ubicacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ubicacion);
        }

        //
        // GET: /Admincp/Ubicacion/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Ubicacion ubicacion = db.Ubicacion.Find(id);
            if (ubicacion == null)
            {
                return HttpNotFound();
            }
            return View(ubicacion);
        }

        //
        // POST: /Admincp/Ubicacion/Edit/5

        [HttpPost]
        public ActionResult Edit(Ubicacion ubicacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ubicacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ubicacion);
        }

        //
        // GET: /Admincp/Ubicacion/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Ubicacion ubicacion = db.Ubicacion.Find(id);
            if (ubicacion == null)
            {
                return HttpNotFound();
            }
            return View(ubicacion);
        }

        //
        // POST: /Admincp/Ubicacion/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            db.PR_ELIMINAR_UBICACION(id);
            Ubicacion ubicacion = db.Ubicacion.Find(id);
            db.Ubicacion.Remove(ubicacion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}