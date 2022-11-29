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
            if (formEmpresa != null)
            {
                var empresa = await _context.empresa.Where(x => x.Id == formEmpresa).FirstOrDefaultAsync();
                List<Models.Escala> escalasNovas = new List<Models.Escala>();
                
                if (formFunc1 != null)
                {
                    var user1 = await _context.user.Where(x => x.Id == formFunc1).FirstOrDefaultAsync();
                    var escala1 = new Models.Escala() { usuario = user1, empresa = empresa, mes = 11, idPessoaEscala = 1 };
                    escalasNovas.Add(escala1);
                }
                if (formFunc2 != null)
                {
                    var user2 = await _context.user.Where(x => x.Id == formFunc2).FirstOrDefaultAsync();
                    var escala2 = new Models.Escala() { usuario = user2, empresa = empresa, mes = 11, idPessoaEscala = 2 };
                    escalasNovas.Add(escala2);
                }
                if (formFunc3 != null)
                {
                    var user3 = await _context.user.Where(x => x.Id == formFunc1).FirstOrDefaultAsync();
                    var escala3 = new Models.Escala() { usuario = user3, empresa = empresa, mes = 11, idPessoaEscala = 3 };
                    escalasNovas.Add(escala3);
                }
                if (formFunc4 != null)
                {
                    var user4 = await _context.user.Where(x => x.Id == formFunc1).FirstOrDefaultAsync();
                    var escala4 = new Models.Escala() { usuario = user4, empresa = empresa, mes = 11, idPessoaEscala = 4 };
                    escalasNovas.Add(escala4);
                }
                if (formFunc5 != null)
                {
                    var user5 = await _context.user.Where(x => x.Id == formFunc1).FirstOrDefaultAsync();
                    var escala5 = new Models.Escala() { usuario = user5, empresa = empresa, mes = 11, idPessoaEscala = 1 };
                    escalasNovas.Add(escala5);
                }

                await _context.Escala.AddRangeAsync(escalasNovas);
                await _context.SaveChangesAsync();
            };
            return RedirectToPage("./listEscala");
        }
    }
}
