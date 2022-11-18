using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WorkSchedule.Data;
using WorkSchedule.Models;

namespace WorkSchedule.Pages.Cargo
{
    public class CreateCargoModel : PageModel
    {
        private readonly WorkSchedule.Data.ApplicationDbContext _context;

        public CreateCargoModel(WorkSchedule.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.Cargo cargo { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.cargo.Add(cargo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./listCargo");
        }
    }
}
