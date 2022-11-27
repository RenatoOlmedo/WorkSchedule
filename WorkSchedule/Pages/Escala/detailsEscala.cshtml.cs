using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkSchedule.Data;
using WorkSchedule.Models;

namespace WorkSchedule.Pages.Escala
{
    public class detailsEscalaModel : PageModel
    {
        private readonly WorkSchedule.Data.ApplicationDbContext _context;

        public detailsEscalaModel(WorkSchedule.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Models.Escala Escala { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Escala == null)
            {
                return NotFound();
            }

            var escala = await _context.Escala.FirstOrDefaultAsync(m => m.id == id);
            if (escala == null)
            {
                return NotFound();
            }
            else 
            {
                Escala = escala;
            }
            return Page();
        }
    }
}
