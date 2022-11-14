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

namespace WorkSchedule.Pages.Empresas
{
    public class detailsEmpresaModel : PageModel
    {
        private readonly WorkSchedule.Data.ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public detailsEmpresaModel(WorkSchedule.Data.ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public Empresa Empresa { get; set; }
        public List<User> gestor { get; set; }
        public List<User> funcionario { get; set; }
        public string status { get; set; }

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
                gestor = new List<User>();
                funcionario = new List<User>();

                Empresa = empresa;
                status = Empresa.status == 1 ? "Ativo" : "Inativo";
                var pessoas = _context.user.Where(x => x.empresa == Empresa).ToList();
                foreach (var pessoa in pessoas)
                {
                    var role = await _userManager.GetRolesAsync(pessoa);
                    if(role.Contains("Empresa"))
                    {
                        gestor.Add(pessoa);
                    }
                    else if(role.Contains("Funcionario"))
                    {
                        funcionario.Add(pessoa);
                    }
                }
            }
            return Page();
        }
    }
}
