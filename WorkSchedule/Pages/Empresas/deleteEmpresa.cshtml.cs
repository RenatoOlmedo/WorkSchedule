using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkSchedule.Data;
using WorkSchedule.Models;

namespace WorkSchedule.Pages.Empresas
{
    public class deleteEmpresaModel : PageModel
    {
        private readonly WorkSchedule.Data.ApplicationDbContext _context;

        public deleteEmpresaModel(WorkSchedule.Data.ApplicationDbContext context)
        {
            _context = context;
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

            if (empresa != null)
            {
                empresa.status = -1;
                Empresa = empresa;
                _context.empresa.Update(Empresa);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
