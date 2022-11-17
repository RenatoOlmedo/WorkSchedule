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

namespace WorkSchedule.Pages.Empresas
{
    public class updateEmpresaModel : PageModel
    {
        private readonly WorkSchedule.Data.ApplicationDbContext _context;

        public updateEmpresaModel(WorkSchedule.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Empresa Empresa { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.empresa == null)
            {
                return NotFound();
            }

            var empresa =  await _context.empresa.FirstOrDefaultAsync(m => m.Id == id);
            if (empresa == null)
            {
                return NotFound();
            }
            Empresa = empresa;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Empresa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresaExists(Empresa.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./ListEmpresas");
        }

        private bool EmpresaExists(int id)
        {
          return _context.empresa.Any(e => e.Id == id);
        }
    }
}
