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

namespace WorkSchedule.Pages.Escala
{
    [Authorize]
    public class listEscalaModel : PageModel
    {
        private readonly WorkSchedule.Data.ApplicationDbContext _context;

        public listEscalaModel(WorkSchedule.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.Empresa> empresa { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Escala != null)
            {
                empresa = await _context.empresa.Where(x => x.escalas != null).Include(x => x.escalas).ToListAsync();
            }
        }
    }
}
