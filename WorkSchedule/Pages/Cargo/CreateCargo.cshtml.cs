using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkSchedule.Data;
using WorkSchedule.Models;

namespace WorkSchedule.Pages.Cargo
{
    [Authorize(Roles = "Empresa, Admin")]
    public class CreateCargoModel : PageModel
    {
        private readonly WorkSchedule.Data.ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public CreateCargoModel(WorkSchedule.Data.ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public List<Empresa> empresas { get; set; }
        public bool admin { get; set; }=false;

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var roles = await _userManager.GetRolesAsync(user);
            if (roles.Contains("Admin"))
            {
                admin = true;
            }

            empresas = await _context.empresa.Where(x => x.status == 1).ToListAsync();
            return Page();
        }

        [BindProperty]
        public Models.Cargo cargo { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(int? empresaId)
        {
            var user = await _userManager.GetUserAsync(User);
            user = await _context.user.Where(x => x.Id == user.Id).Include(x => x.empresa).FirstOrDefaultAsync();

            if (empresaId != null)
            {
                var empresa = await _context.empresa.Where(x => x.status == 1 && x.Id == empresaId).FirstOrDefaultAsync();
                cargo.empresa = empresa;
            }
            else
            {
                cargo.empresa = user.empresa;
            }

            _context.cargo.Add(cargo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./listCargo");
        }
    }
}
