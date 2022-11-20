using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkSchedule.Data;
using WorkSchedule.Models;

namespace WorkSchedule.Pages.Cargo
{
    public class updateCargoModel : PageModel
    {
        private readonly WorkSchedule.Data.ApplicationDbContext _context;

        public updateCargoModel(WorkSchedule.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Cargo Cargo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.cargo == null)
            {
                return NotFound();
            }

            var cargo =  await _context.cargo.FirstOrDefaultAsync(m => m.id == id);
            if (cargo == null)
            {
                return NotFound();
            }
            Cargo = cargo;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            _context.Attach(Cargo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CargoExists(Cargo.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./listCargo");
        }

        private bool CargoExists(int id)
        {
          return _context.cargo.Any(e => e.id == id);
        }
    }
}
