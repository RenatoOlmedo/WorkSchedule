using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WorkSchedule.Data;
using WorkSchedule.Models;

namespace WorkSchedule.Pages
{
    [Authorize(Roles = "Empresa, Admin")]
    public class EmpresasModel : PageModel
    {
        private readonly WorkSchedule.Data.ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public EmpresasModel(WorkSchedule.Data.ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Empresa Empresa { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.empresa.Add(Empresa);

            user.empresa = Empresa;
            _context.Update(user);

            await _userManager.AddToRoleAsync(user, "AdmEmpresa");
            await _context.SaveChangesAsync();


            return RedirectToPage("/Empresas/ListEmpresas");
        }
    }
}
