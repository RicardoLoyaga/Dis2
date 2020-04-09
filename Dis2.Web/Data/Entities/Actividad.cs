using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dis2.Web.Data.Entities
{
    public class Actividad
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas {1} caracteres")]
        public string Nombre { get; set; }

        public string Detalle { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(1, ErrorMessage = "El campo {0} no puede tener mas {1} caracteres")]
        public string Estado { get; set; }

        public Ejercicio Ejercicio { get; set; }

        public ICollection<Imagen> Imagens { get; set; }

        public ICollection<Video> Videos { get; set; }

        public ICollection<Sonido> Sonidos { get; set; }
    }
}
