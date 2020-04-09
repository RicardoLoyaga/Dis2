﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dis2.Web.Data.Entities
{
    public class Especialista
    {
        public int Id { get; set; }

        public Usuario Usuario { get; set; }

        public ICollection<Historia> Historias { get; set; }
    }
}
