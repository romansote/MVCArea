using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcArea.Areas.Admincp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data.Objects;
using System.Data.Common;


namespace MvcArea.Areas.Admincp.Controllers
{
    public class PanelController : Controller
    {

        webdivEntities11 dc = new webdivEntities11();
        //
        // GET: /Admincp/Panel/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        // previene falsa autentificacion
        [ValidateAntiForgeryToken]
        //login (hereda atributos model, y url)
        public ActionResult login(LoginModel l, string ReturnUrl = "")
        {
            
            // creamos instancia de la base de datos
            using (webdivEntities11 dc = new webdivEntities11())
            {
                // capturamos en variable user el resultado a la consulta 
                var user = dc.Usuarios.Where(a => a.usuario.Equals(l.usuario) && a.contraseña.Equals(l.contraseña)).FirstOrDefault();
                // si el resultado es diferente a nulo existen los datos ingresados a la bd
                if (user != null)
                {
                    // creamos un cookie con usuario y recordar
                    FormsAuthentication.SetAuthCookie(user.usuario, l.recordar);

                    // guardamos registros de usuario conectado
                    this.guardarLogin(user.id_usuario);
                    
                    FormsAuthentication.Timeout.Add(TimeSpan.FromMinutes(1));
                    // verificamos si la vista a la que redireccionaremos es propia de la clase
                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                         
                        // redireccionamos al panel principal <accion> <Controller> <area>
                        return RedirectToAction("Index", "Panel", new { area = "Admincp" });
                    }
                }
            }
            ModelState.Remove("contraseña");
            return View();
        }
      

        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login");
        }

        public void guardarLogin(int id_usuario)
        {
            using (webdivEntities11 dc = new webdivEntities11())
            {
                Registros_login x = new Registros_login

                {
                    id_usuario = Convert.ToInt32(id_usuario),
                    fecha = DateTime.Now.ToString(),
                };

                dc.Registros_login.Add(x);
                dc.SaveChanges();
            }
 
        }

        public ActionResult VerRegistrosLogin()
        {
                
            return View(dc.PR_LISTAR_REGISTROSLOGIN());
        }


    }
}
