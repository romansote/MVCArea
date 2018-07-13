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
    public class UsuariosController : Controller
    {
        private webdivEntities11 db = new webdivEntities11();


        //
        // GET: /Admincp/Usuarios/

        public ActionResult Index()
        {
            return View(db.Usuarios.ToList());
        }

        //
        // GET: /Admincp/Usuarios/Details/5

        public ActionResult Details(int id = 0)
        {
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        //
        // GET: /Admincp/Usuarios/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admincp/Usuarios/Create

        [HttpPost]
        public ActionResult Create(Usuarios usuarios)
        {

            /** almacenamos resultado de consulta en la variable query
             * decimos que u sera igual a nuestra tabla "usuarios",luego preguntamos si los usuarios que estan alnacenados en
             * nuestra bd son iguales a los que estamos ingresando por formulario, despues aplicamos el metodo "count" que cuenta los resultados
             **/
            var query = (from u in db.Usuarios where u.usuario == usuarios.usuario select u).Count();
            /**
             * preguntamos si el total de filas que encontro nuestra queri es igual a = 0(0 significa que no existe ninguna coincidencia en el usuarios
             * que estamos ingresando
             * **/
            if (query == 0)
            {
                if (ModelState.IsValid)
                {
                    db.Usuarios.Add(usuarios);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {

                return RedirectToAction("Create");
            }
            return View(usuarios);
        }
        // GET: /Admincp/Usuarios/Edit/5

        public void guardarLogin()
        {
            Usuarios user = new Usuarios();
        }

        public ActionResult Edit(int id = 0)
        {
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        //
        // POST: /Admincp/Usuarios/Edit/5

        [HttpPost]
        public ActionResult Edit(Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuarios);
        }

        //
        // GET: /Admincp/Usuarios/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }



        //
        // POST: /Admincp/Usuarios/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {

            db.PR_ELIMINAR_REGISTROLOGIN(id);

            Usuarios usuarios = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuarios);
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