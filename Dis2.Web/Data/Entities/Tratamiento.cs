using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dis2.Web.Data.Entities
{
    public class Tratamiento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas {1} caracteres")]
        public string Nombre { get; set; }

        [Display(Name ="Numero Terapias")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int NumeroTerapias { get; set; }

        public string Detalle { get; set; }

        public Historia Historia { get; set; }

        public TipoTratamiento TipoTratamiento { get; set; }

        public ICollection<Ejercicio> Ejercicios { get; set; }
    }
}
