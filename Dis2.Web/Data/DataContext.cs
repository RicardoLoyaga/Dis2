using Dis2.Web.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dis2.Web.Data
{
    public class DataContext : IdentityDbContext<Usuario>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Administrador> administradors { get; set; }
        public DbSet<Titular> titulars  { get; set; }
        public DbSet<Actividad> actividads { get; set; }
        public DbSet<Ejercicio> ejercicios { get; set; }
        public DbSet<Especialista> especialistas { get; set; }
        public DbSet<Historia> historias { get; set; }
        public DbSet<Imagen> imagens { get; set; }
        public DbSet<Paciente> pacientes { get; set; }
        public DbSet<Sonido> sonidos { get; set; }
        public DbSet<TipoTratamiento> tipoTratamientos { get; set; }
        public DbSet<Tratamiento> tratamientos { get; set; }
        public DbSet<Video> videos { get; set; }
    }
}
