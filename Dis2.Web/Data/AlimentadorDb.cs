using Dis2.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dis2.Web.Data
{
    public class AlimentadorDb
    {
        private readonly DataContext _context;
        public AlimentadorDb(DataContext context)
        {
            _context = context;
        }

        public async Task AlimentadorAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckTipoTratamientosAsync();
            await CheckActividadsAsync();
            await CheckEjerciciosAsync();
            //await CheckHistoriasAsync();
            await CheckImagensAsync();
            await CheckPacientesAsync();
            await CheckSonidosAsync();
            await CheckTitularsAsync();
            await CheckTratamientosAsync();
            await CheckVideosAsync();
        }

        private Task CheckVideosAsync()
        {
            /*var actividad = _context.actividads.FirstOrDefault();
            if (!_context.videos.Any())
            {
                _context.videos.Add(new Video { Nombre = "LETRAB", VideoUrl = "", Estado = "A",  });
                _context.videos.Add(new Video { Nombre = "LETRAC", VideoUrl = "", Estado = "A" });
                await _context.SaveChangesAsync();
            }*/
            throw new NotImplementedException();
        }

        private Task CheckTratamientosAsync()
        {
            throw new NotImplementedException();
        }

        private Task CheckTitularsAsync()
        {
            throw new NotImplementedException();
        }

        private Task CheckSonidosAsync()
        {
            throw new NotImplementedException();
        }

        private Task CheckPacientesAsync()
        {
            throw new NotImplementedException();
        }

        private Task CheckImagensAsync()
        {
            throw new NotImplementedException();
        }


        private async Task CheckEjerciciosAsync()
        {
            if (!_context.ejercicios.Any())
            {
                _context.ejercicios.Add(new Ejercicio { Nombre = "BUCOFACIALES", Detalle = "MOVIMIENTOS DE LAS ARTICULACIONES FACIALES", Estado = "A" });
                _context.ejercicios.Add(new Ejercicio { Nombre = "RESPIRATORIOS", Detalle = "CONTROLAR LA RESPIRACION", Estado = "A" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckActividadsAsync()
        {
            if (!_context.actividads.Any())
            {
                _context.actividads.Add(new Actividad { Nombre = "MOVIMIENTOS EXTERNOS DE LA LENGUA", Detalle = "TERAPIA EMPLEADA EN NIÑOS", Estado = "A" });
                _context.actividads.Add(new Actividad { Nombre = "MOVIMIENTOS INTERNOS DE LA LENGUA", Detalle = "TERAPIA EMPLEADA EN NIÑOS", Estado = "A" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckTipoTratamientosAsync()
        {
            if (!_context.tipoTratamientos.Any())
            {
                _context.tipoTratamientos.Add(new TipoTratamiento { Nombre = "INDIRECTO" });
                _context.tipoTratamientos.Add(new TipoTratamiento { Nombre = "DIRECTO" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
