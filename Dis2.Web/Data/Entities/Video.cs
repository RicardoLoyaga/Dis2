using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dis2.Web.Data.Entities
{
    public class Video
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas {1} caracteres")]
        public string Nombre { get; set; }

        [Display(Name = "Video")]
        public string VideoUrl { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(1, ErrorMessage = "El campo {0} no puede tener mas {1} caracteres")]
        public string Estado { get; set; }

        public string VideoFullPath => string.IsNullOrEmpty(VideoUrl)
            ? null
            : $"https://TDB.azurewebsites.net{VideoUrl.Substring(1)}";

        public Actividad Actividad { get; set; }
    }
}
