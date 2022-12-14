using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkSchedule.Data;
using WorkSchedule.Models;

namespace WorkSchedule.Pages.Empresas
{
    [Authorize(Roles = "Empresa, Admin")]
    public class deleteEmpresaModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly WorkSchedule.Data.ApplicationDbContext _context;

        public deleteEmpresaModel(WorkSchedule.Data.ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
      public Empresa Empresa { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.empresa == null)
            {
                return NotFound();
            }

            var empresa = await _context.empresa.FirstOrDefaultAsync(m => m.Id == id);

            if (empresa == null)
            {
                return NotFound();
            }
            else 
            {
                Empresa = empresa;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.empresa == null)
            {
                return NotFound();
            }
            var empresa = await _context.empresa.FindAsync(id);
            var users = await _context.user.Where(x => x.empresa == empresa).ToListAsync();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, roles.ToArray());
            }

            if (empresa != null)
            {
                empresa.status = -1;
                Empresa = empresa;
                _context.empresa.Update(Empresa);

                if(users != null)
                {
                    foreach (var user in users)
                    {
                        user.empresa = null;
                    }
                    _context.UpdateRange(users);
                }
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./ListEmpresas");
        }
    }
}
