// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkSchedule.Data;
using WorkSchedule.Models;

namespace WorkSchedule.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationDbContext _db;

        public List<Empresa> empresas { get; set; }
        public Models.User usuario { get; set; }
        public string role { get; set; }
        public IndexModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "Número do telefone")]
            public string PhoneNumber { get; set; }
        }

        private async Task LoadAsync(User user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            usuario = await _userManager.GetUserAsync(User);
            usuario = await _db.user.Where(x => x.Id == usuario.Id).Include(x => x.empresa).FirstOrDefaultAsync();
            if (usuario == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            var roles = await _userManager.GetRolesAsync(usuario);
            if (roles.Contains("Empresa"))
            {
                role = "empresa";
            }
            if (roles.Contains("Funcionario"))
            {
                role = "funcionario";
            }
            empresas = _db.empresa.Where(x => x.status ==1).ToList();
            await LoadAsync(usuario);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string telefone, int? empresaId, string tipo_pessoa, string? nomeCompleto)
        {
            usuario = await _userManager.GetUserAsync(User);
            usuario = await _db.user.Where(x => x.Id == usuario.Id).FirstOrDefaultAsync();
            
            if (usuario == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            if (!ModelState.IsValid)
            {
                await LoadAsync(usuario);
                return Page();
            }

            if (!String.IsNullOrEmpty(tipo_pessoa))
            {
                await _userManager.AddToRoleAsync(usuario, tipo_pessoa);
            }

            if (empresaId.HasValue)
            {
                var empresa = await _db.empresa.Where(x => x.Id == empresaId).FirstOrDefaultAsync();
                usuario.empresa = empresa;
                _db.user.Update(usuario);
                await _db.SaveChangesAsync();
            }
            if (nomeCompleto != null)
            {
                usuario.nomeCompleto = nomeCompleto;
                _db.user.Update(usuario);
                await _db.SaveChangesAsync();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(usuario);
            if (telefone != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(usuario, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Erro inesperado tentado alterar seu telefone.";
                    return RedirectToPage();
                }
            }

            await _signInManager.RefreshSignInAsync(usuario);
            StatusMessage = "Seu perfil foi atualizado";
            if(tipo_pessoa == "Empresa")
            {
                return Redirect("/Empresas/ListEmpresas");
            }
            return RedirectToPage();
        }
    }
}
