using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MvcArea.Areas.Admincp.Models
{
    public class LoginModel
    {
        // validacion de usuario, permitir espacio vacio = falso
        [Required(ErrorMessage = "Usuario requerido.", AllowEmptyStrings = false)]
        // definir usuario
        [MaxLength(10)]
        public string usuario { get; set; }

        [MaxLength(10)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Usuario requerido.", AllowEmptyStrings = false)]
        public string contraseña { get; set; }
        public bool recordar { get; set; }

       
        


    }
}