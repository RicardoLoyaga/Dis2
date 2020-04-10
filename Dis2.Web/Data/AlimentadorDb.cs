using Dis2.Web.Data.Entities;
using Dis2.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dis2.Web.Data
{
    public class AlimentadorDb
    {
        private readonly DataContext _dataContext;
        private readonly IUsuarioHelper _usuarioHelper;

        public AlimentadorDb(
            DataContext context,
            IUsuarioHelper usuarioHelper)
        {
            _dataContext = context;
            _usuarioHelper = usuarioHelper;
        }

        public async Task AlimentadorAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckRoles();
            var administrador = await CheckUsuarioAsync("1721515680", "BRYAN RICARDO", "ARMAS LOYAGA", "0996903086", "EL CONDE", "bral_9210@hotmail.com", "A", "1992/11/01" ,"Administrador");
            var cliente = await CheckUsuarioAsync("1723620348", "ERIKA ANNABELL", "MONTESDEOCA CARGUA", "0996907141", "EL CONDE", "erika_annabell@hotmail.com", "A", "1994/02/02", "Cliente");
            await CheckTipoTratamientosAsync();
            await CheckActividadsAsync();
            await CheckEjerciciosAsync();
            //await CheckHistoriasAsync();
            await CheckImagensAsync();
            await CheckPacientesAsync(cliente);
            await CheckSonidosAsync();
            await CheckTitularsAsync(cliente);
            await CheckAdministradorsAsync(administrador);
            await CheckTratamientosAsync();
            await CheckVideosAsync();
        }

        private async Task CheckAdministradorsAsync(Usuario usuario)
        {
            if (!_dataContext.administradors.Any())
            {
                _dataContext.administradors.Add(new Administrador { Usuario = usuario });
                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckRoles()
        {
            await _usuarioHelper.CheckRolAsync("Administrador");
            await _usuarioHelper.CheckRolAsync("Cliente");
        }

        private async Task<Usuario> CheckUsuarioAsync(
            string identificacion,
            string nombres,
            string apellidos,
            string telefono,
            string direccion,
            string correo,
            string estado,
            string fechaNacimiento,
            string rol)
        {
            var user = await _usuarioHelper.GetUsuarioByEmailAsync(correo);
            if (user == null)
            {
                user = new Usuario
                {
                    Nombres = nombres,
                    Apellidos = apellidos,
                    Email = correo,
                    UserName = correo,
                    PhoneNumber = telefono,
                    Direccion = direccion,
                    Estado = estado,
                    FechaNacimiento = DateTime.Parse(fechaNacimiento),
                    Identificacion = identificacion
                };

                await _usuarioHelper.AddUsuarioAsync(user, "123456");
                await _usuarioHelper.AddUsuarioPorRolAsync(user, rol);

                //var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                //await _userHelper.ConfirmEmailAsync(user, token);
            }

            return user;
        }

        private async Task CheckVideosAsync()
        {
            if (!_dataContext.videos.Any())
            {
                var actividad = _dataContext.actividads.FirstOrDefault();
                AddVideo("LETRA B", actividad, "letraB.mp4", "A");
                AddVideo("LETRA C", actividad, "letraC.mp4", "A");
                await _dataContext.SaveChangesAsync();
            }
        }

        private void AddVideo(string nombre, Actividad actividad, string url, string estado)
        {
            _dataContext.videos.Add(new Video
            {
                Nombre = nombre,
                Actividad = actividad,
                VideoUrl = url,
                Estado = estado
            }); ;
        }

        private async Task CheckTratamientosAsync()
        {
            if (!_dataContext.tratamientos.Any())
            {
                var historia = _dataContext.historias.FirstOrDefault();
                var tipoTratamiento = _dataContext.tipoTratamientos.FirstOrDefault();
                AddTratamiento("FONEMA B", 10, historia, tipoTratamiento, "REALIZAR 10 TERAPIAS DEL FONEMA B");
                AddTratamiento("FONEMA C", 10, historia, tipoTratamiento, "REALIZAR 10 TERAPIAS DEL FONEMA C");
                await _dataContext.SaveChangesAsync();
            }
        }

        private void AddTratamiento(
            string nombre, 
            int numeroTerapias, 
            Historia historia, 
            TipoTratamiento tipoTratamiento, 
            string detalle)
        {
            _dataContext.tratamientos.Add(new Tratamiento
            {
                Nombre = nombre,
                NumeroTerapias = numeroTerapias,
                Historia = historia,
                TipoTratamiento = tipoTratamiento,
                Detalle = detalle
            }); 
        }

        private async Task CheckTitularsAsync(Usuario usuario)
        {
            if (!_dataContext.titulars.Any())
            {
                _dataContext.titulars.Add(new Titular { Usuario = usuario });
                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckSonidosAsync()
        {
            if (!_dataContext.sonidos.Any())
            {
                var actividad = _dataContext.actividads.FirstOrDefault();
                AddSonido("LETRA B", actividad, "letraB.mp3", "A");
                AddSonido("LETRA C", actividad, "letraC.mp3", "A");
                await _dataContext.SaveChangesAsync();
            }
        }

        private void AddSonido(string nombre, Actividad actividad, string url, string estado)
        {
            _dataContext.sonidos.Add(new Sonido
            {
                Nombre = nombre,
                Actividad = actividad,
                SonidoUrl = url,
                Estado = estado
            }); ;
        }

        private async Task CheckPacientesAsync(Usuario usuario)
        {
            if (!_dataContext.pacientes.Any())
            {
                _dataContext.pacientes.Add(new Paciente { Usuario = usuario });
                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckImagensAsync()
        {
            if (!_dataContext.imagens.Any())
            {
                var actividad = _dataContext.actividads.FirstOrDefault();
                AddImagen("MUEVE LABIOS", actividad, "ejeMueveLabio.png", "A");
                AddImagen("MUEVE BOCA", actividad, "ejeMueveBoca.png", "A");
                await _dataContext.SaveChangesAsync();
            }
        }

        private void AddImagen(string nombre, Actividad actividad, string url, string estado)
        {
            _dataContext.imagens.Add(new Imagen
            {
                Nombre = nombre,
                Actividad = actividad,
                ImagenUrl = url,
                Estado = estado
            });
        }


        private async Task CheckEjerciciosAsync()
        {
            if (!_dataContext.ejercicios.Any())
            {
                var tratamiento = _dataContext.tratamientos.FirstOrDefault();
                AddEjercicio("BUCOFACIALES", "MOVIMIENTOS DE LAS ARTICULACIONES FACIALES", tratamiento, "A");
                AddEjercicio("RESPIRATORIOS", "CONTROLAR LA RESPIRACION", tratamiento, "A");
                await _dataContext.SaveChangesAsync();
            }
            
        }

        private void AddEjercicio(string nombre, string detalle,Tratamiento tratamiento, string estado)
        {
            _dataContext.ejercicios.Add(new Ejercicio
            {
                Nombre = nombre,
                Detalle = detalle,
                Tratamiento = tratamiento,
                Estado = estado
            });
        }

        private async Task CheckActividadsAsync()
        {
            if (!_dataContext.actividads.Any())
            {
                var ejercicio = _dataContext.ejercicios.FirstOrDefault();
                AddActividad("MOVIMIENTOS EXTERNOS DE LA LENGUA", "TERAPIA EMPLEADA EN NIÑOS", ejercicio, "A");
                AddActividad("MOVIMIENTOS INTERNOS DE LA LENGUA", "TERAPIA EMPLEADA EN NIÑOS", ejercicio, "A");
                await _dataContext.SaveChangesAsync();
            }
            
        }

        private void AddActividad(string nombre, string detalle, Ejercicio ejercicio, string estado)
        {
            _dataContext.actividads.Add(new Actividad
            {
                Nombre = nombre,
                Detalle = detalle,
                Ejercicio = ejercicio,
                Estado = estado
            });
        }

        private async Task CheckTipoTratamientosAsync()
        {
            if (!_dataContext.tipoTratamientos.Any())
            {
                _dataContext.tipoTratamientos.Add(new TipoTratamiento { Nombre = "INDIRECTO" });
                _dataContext.tipoTratamientos.Add(new TipoTratamiento { Nombre = "DIRECTO" });
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
