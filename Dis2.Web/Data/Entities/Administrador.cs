using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dis2.Web.Data.Entities
{
    public class Administrador
    {
        public int Id { get; set; }

        public Usuario Usuario { get; set; }
    }
}
