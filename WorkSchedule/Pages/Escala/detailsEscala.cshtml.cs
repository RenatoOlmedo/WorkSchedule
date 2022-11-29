using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkSchedule.Data;
using WorkSchedule.Models;

namespace WorkSchedule.Pages.Escala
{
    public class detailsEscalaModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly WorkSchedule.Data.ApplicationDbContext _context;

        public detailsEscalaModel(WorkSchedule.Data.ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

      public Models.Escala Escala { get; set; }
      public List<Models.Escala> escalas { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var empresa = await _context.empresa.Where(x => x.Id == id).FirstOrDefaultAsync();
            escalas = await _context.Escala.Where(x => x.empresa == empresa).Include(x => x.usuario).ToListAsync();
            if (empresa != null)
            {
                var user = await _userManager.GetUserAsync(User);
                user = await _context.user.Where(x => x.Id == user.Id).Include(x => x.empresa).FirstOrDefaultAsync();

                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains("Funcionario"))
                {
                    escalas.Clear();
                    escalas = await _context.Escala.Where(x => x.empresa == empresa && x.usuario == user).Include(x => x.usuario).ToListAsync();
                }
            }

            return Page();
        }
    }
}
