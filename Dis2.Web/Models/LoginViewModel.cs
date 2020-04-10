using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dis2.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [EmailAddress(ErrorMessage = "El campo {0} no es una dirección de correo válida")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MinLength(6)]
        public string Contrasena { get; set; }
        public bool Recordar { get; set; }
    }
}
