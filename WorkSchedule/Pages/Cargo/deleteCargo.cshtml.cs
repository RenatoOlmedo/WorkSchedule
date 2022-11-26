using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkSchedule.Data;
using WorkSchedule.Models;

namespace WorkSchedule.Pages.Cargo
{
    [Authorize(Roles = "Empresa, Admin")]
    public class deleteCargoModel : PageModel
    {
        private readonly WorkSchedule.Data.ApplicationDbContext _context;

        public deleteCargoModel(WorkSchedule.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Models.Cargo Cargo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.cargo == null)
            {
                return NotFound();
            }

            var cargo = await _context.cargo.FirstOrDefaultAsync(m => m.id == id);

            if (cargo == null)
            {
                return NotFound();
            }
            else 
            {
                Cargo = cargo;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.cargo == null)
            {
                return NotFound();
            }
            var cargo = await _context.cargo.FindAsync(id);

            if (cargo != null)
            {
                cargo.status = -1;
                Cargo = cargo;
                _context.cargo.Update(cargo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./listCargo");
        }
    }
}
