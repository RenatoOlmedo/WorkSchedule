using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkSchedule.Data;
using WorkSchedule.Models;

namespace WorkSchedule.Pages.Escala
{
    public class createEscalaModel : PageModel
    {
        private readonly WorkSchedule.Data.ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        public Empresa empresa { get; set; }
        public List<User> funcionarios { get; set; }
        public createEscalaModel(WorkSchedule.Data.ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGet()
        {
            funcionarios = new List<User>();
            var user = await _userManager.GetUserAsync(User);
            user = await _context.user.Where(x => x.Id == user.Id).Include(x => x.empresa).FirstOrDefaultAsync();
            empresa = user.empresa;

            var pessoasEmpresa  = await _context.user.Where(x => x.empresa == empresa).Include(x => x.cargo).ToListAsync();
            foreach (var pessoa in pessoasEmpresa)
            {
                var roles = await _userManager.GetRolesAsync(pessoa);
                if (!roles.Contains("Admin"))
                {
                    funcionarios.Add(pessoa);
                }
            }

            return Page();
        }

        [BindProperty]
        public Models.Escala Escala { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(int? formQntFuncionarios, string? formFunc1, string? formFunc2, string? formFunc3, string? formFunc4, string? formFunc5, int? formEmpresa)
        {


            return RedirectToPage("./listEscala");
        }
    }
}
