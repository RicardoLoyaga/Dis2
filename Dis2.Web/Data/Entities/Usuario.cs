using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dis2.Web.Data.Entities
{
    public class Usuario : IdentityUser
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(15, ErrorMessage = "El campo {0} no puede tener mas {1} caracteres")]
        public string Identificacion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas {1} caracteres")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas {1} caracteres")]
        public string Apellidos { get; set; }

        [MaxLength(10, ErrorMessage = "El campo {0} no puede tener mas {1} caracteres")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(200, ErrorMessage = "El campo {0} no puede tener mas {1} caracteres")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(200, ErrorMessage = "El campo {0} no puede tener mas {1} caracteres")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(1, ErrorMessage = "El campo {0} no puede tener mas {1} caracteres")]
        public string Estado { get; set; }

        public string NombreCompleto => $"{Nombres} {Apellidos}";
    }
}
