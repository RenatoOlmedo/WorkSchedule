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

namespace WorkSchedule.Pages
{
    [Authorize(Roles = "Empresa, Admin")]
    public class ListEmpresasModel : PageModel
    {
        private readonly WorkSchedule.Data.ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        public bool isAdmin { get; set; } = false;
        public bool isEmpresa { get; set; } = false;
        public bool isAdmEmpresa { get; set; } = false;

        public ListEmpresasModel(WorkSchedule.Data.ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public List<Empresa> Empresa { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Empresa = new List<Empresa>();

            var user = await _userManager.GetUserAsync(User);
            user = await _context.user.Where(x => x.Id == user.Id).Include(x => x.empresa).FirstOrDefaultAsync();

            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Contains("Admin"))
            {
                isAdmin = true;
                if (_context.empresa != null)
                {
                    Empresa = await _context.empresa.ToListAsync();
                }
            }
            else
            {
                isEmpresa = true;
                if (roles.Contains("AdmEmpresa"))
                {
                    isAdmEmpresa = true;
                }
                    if (_context.empresa != null && user.empresa != null)
                {
                    Empresa.Add(user.empresa);
                }
            }
        }
    }
}
