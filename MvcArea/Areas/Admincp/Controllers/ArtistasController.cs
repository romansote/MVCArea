using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcArea.Areas.Admincp.Controllers
{
    public class ArtistasController : Controller
    {
        private webdivEntities11 db = new webdivEntities11();

        //
        // GET: /Admincp/Artistas/

        public ActionResult Index()
        {
            return View(db.Artistas.ToList());
        }

        //
        // GET: /Admincp/Artistas/Details/5

        public ActionResult Details(int id = 0)
        {
            Artistas artistas = db.Artistas.Find(id);
            if (artistas == null)
            {
                return HttpNotFound();
            }
            return View(artistas);
        }

        //
        // GET: /Admincp/Artistas/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admincp/Artistas/Create

        [HttpPost]
        public ActionResult Create(Artistas artistas)
        {
            if (ModelState.IsValid)
            {
                db.Artistas.Add(artistas);
                db.SaveChanges();

             //   return Content("<script language='javascript' type='text/javascript'>alert('Data Already Exists');</script>");
                return RedirectToAction("Index");
            }
          
            return View(artistas);
        }

        //
        // GET: /Admincp/Artistas/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Artistas artistas = db.Artistas.Find(id);
            if (artistas == null)
            {
                return HttpNotFound();
            }
            return View(artistas);
        }

        //
        // POST: /Admincp/Artistas/Edit/5

        [HttpPost]
        public ActionResult Edit(Artistas artistas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artistas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artistas);
        }

        //
        // GET: /Admincp/Artistas/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Artistas artistas = db.Artistas.Find(id);
            if (artistas == null)
            {
                return HttpNotFound();
            }
            return View(artistas);
        }

        //
        // POST: /Admincp/Artistas/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            // elimina obras del artista que se esta eliminando
            db.PR_ELIMINAR_OBRAS(id);

            Artistas artistas = db.Artistas.Find(id);
            db.Artistas.Remove(artistas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
      

        public ActionResult MostrarObrasArtistas(int id = 0)
        {
            var query1 = db.PR_LISTAR_OBRAS_ARTISTA(id);

            return View(query1.ToList());
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}