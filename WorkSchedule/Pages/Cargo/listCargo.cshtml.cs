using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkSchedule.Data;
using WorkSchedule.Models;

namespace WorkSchedule.Pages.Cargo
{
    public class listCargoModel : PageModel
    {
        private readonly WorkSchedule.Data.ApplicationDbContext _context;
        public listCargoModel(WorkSchedule.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.Cargo> Cargo { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.cargo != null)
            {
                Cargo = await _context.cargo.ToListAsync();
            }
        }
    }
}
