using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkSchedule.Data;
using WorkSchedule.Models;

namespace WorkSchedule.Pages.Cargo
{
    [Authorize(Roles = "Empresa, Admin")]
    public class listCargoModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly WorkSchedule.Data.ApplicationDbContext _context;
        public listCargoModel(WorkSchedule.Data.ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public List<Models.Cargo> cargos { get; set; }
        public bool precisaVincularEmpresa { get; set; }
        public async Task OnGetAsync()
        {
            cargos = new List<Models.Cargo>();

            var user = await _userManager.GetUserAsync(User);
            user = await _context.user.Where(x => x.Id == user.Id).Include(x => x.empresa).FirstOrDefaultAsync();

            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Contains("Admin"))
            {
                cargos = await _context.cargo.ToListAsync();
            }
            else
            {
                if (user.empresa != null)
                {
                    var cargosEmpresa = await _context.cargo.Where(x => x.empresa == user.empresa && x.status == 1).ToListAsync();
                    cargos = cargosEmpresa;
                }
                else
                    precisaVincularEmpresa = true;
            }
        }
    }
}
