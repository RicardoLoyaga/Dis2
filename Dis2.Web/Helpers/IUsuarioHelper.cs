using Dis2.Web.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dis2.Web.Helpers
{
    public interface IUsuarioHelper
    {
        Task<Usuario> GetUsuarioByEmailAsync(string email);
        Task<IdentityResult> AddUsuarioAsync(Usuario usuario, string contrasena);
        Task CheckRolAsync(string nombreRol);
        Task AddUsuarioPorRolAsync(Usuario usuario, string nombreRol);
        Task<bool> IsUsuarioInRolAsync(Usuario usuario, string nombreRol);
    }
}
