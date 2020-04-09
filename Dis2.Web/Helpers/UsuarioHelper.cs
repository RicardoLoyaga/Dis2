using Dis2.Web.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dis2.Web.Helpers
{
    public class UsuarioHelper : IUsuarioHelper
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsuarioHelper(
            UserManager<Usuario> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> AddUsuarioAsync(Usuario usuario, string contrasena)
        {
            return await _userManager.CreateAsync(usuario, contrasena);
        }

        public async Task AddUsuarioPorRolAsync(Usuario usuario, string nombreRol)
        {
            await _userManager.AddToRoleAsync(usuario, nombreRol);
        }

        public async Task CheckRolAsync(string nombreRol)
        {
            var existeRol = await _roleManager.RoleExistsAsync(nombreRol);
            if (!existeRol)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = nombreRol
                }); ;
            }
        }

        public async Task<Usuario> GetUsuarioByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<bool> IsUsuarioInRolAsync(Usuario usuario, string nombreRol)
        {
            return await _userManager.IsInRoleAsync(usuario, nombreRol);
        }
    }
}
