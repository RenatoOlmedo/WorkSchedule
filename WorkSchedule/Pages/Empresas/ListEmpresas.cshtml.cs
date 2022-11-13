using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkSchedule.Data;
using WorkSchedule.Models;

namespace WorkSchedule.Pages
{
    public class ListEmpresasModel : PageModel
    {
        private readonly WorkSchedule.Data.ApplicationDbContext _context;

        public ListEmpresasModel(WorkSchedule.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Empresa> Empresa { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.empresa != null)
            {
                Empresa = await _context.empresa.ToListAsync();
            }
        }
    }
}
