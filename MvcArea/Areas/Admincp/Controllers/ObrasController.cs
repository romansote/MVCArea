using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcArea.Areas.Admincp.Models;

namespace MvcArea.Areas.Admincp.Controllers
{
    public class ObrasController : Controller
    {
        private webdivEntities11 db = new webdivEntities11();

        //
        // GET: /Admincp/Obras/

        public ActionResult Index()
        {
        
            return View(db.Obras.ToList());
        }

        //
        // GET: /Admincp/Obras/Details/5

        public ActionResult Details(int id = 0)
        {
            Obras obras = db.Obras.Find(id);
            if (obras == null)
            {
                return HttpNotFound();
            }
            return View(obras);
        }

        //
        // GET: /Admincp/Obras/Create

        public ActionResult Create()
        {
            ViewBag.id_Artista = new SelectList(db.Artistas, "id_Artista", "nombre");
            ViewBag.id_Recepcion = new SelectList(db.Ubicacion, "id_Recepcion", "Ubicacion1");
            return View();
        }

        //
        // POST: /Admincp/Obras/Create

        [HttpPost]
        public ActionResult Create(Obras obras)
        {
            if (ModelState.IsValid)
            {
                db.Obras.Add(obras);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Artista = new SelectList(db.Artistas, "id_Artista", "nombre", obras.id_Artista);
            ViewBag.id_Recepcion = new SelectList(db.Ubicacion, "id_Recepcion", "Ubicacion1", obras.id_Recepcion);
            return View(obras);
        }

        //
        // GET: /Admincp/Obras/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Obras obras = db.Obras.Find(id);
            if (obras == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Artista = new SelectList(db.Artistas, "id_Artista", "nombre", obras.id_Artista);
            ViewBag.id_Recepcion = new SelectList(db.Ubicacion, "id_Recepcion", "Ubicacion1", obras.id_Recepcion);
            return View(obras);
        }

        //
        // POST: /Admincp/Obras/Edit/5

        [HttpPost]
        public ActionResult Edit(Obras obras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(obras).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e) { 
                
                }
                return RedirectToAction("Index");
            }
            ViewBag.id_Artista = new SelectList(db.Artistas, "id_Artista", "nombre", obras.id_Artista);
            ViewBag.id_Recepcion = new SelectList(db.Ubicacion, "id_Recepcion", "Ubicacion1", obras.id_Recepcion);
            return View(obras);
        }

        //
        // GET: /Admincp/Obras/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Obras obras = db.Obras.Find(id);
            if (obras == null)
            {
                return HttpNotFound();
            }
            return View(obras);
        }

        //
        // POST: /Admincp/Obras/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Obras obras = db.Obras.Find(id);
            db.Obras.Remove(obras);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

         public ActionResult listarObras(){

           var query = db.PR_LISTAR_OBRAS_DEL_AÑO();

            return View(query.ToList());
           //  return View();
        
        }
    }
}