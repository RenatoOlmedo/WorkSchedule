using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkSchedule.Data;
using WorkSchedule.Models;

namespace WorkSchedule.Pages.Cargo
{
    [Authorize(Roles = "Empresa, Admin")]
    public class CreateCargoModel : PageModel
    {
        private readonly WorkSchedule.Data.ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public CreateCargoModel(WorkSchedule.Data.ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.Cargo cargo { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            user = await _context.user.Where(x => x.Id == user.Id).Include(x => x.empresa).FirstOrDefaultAsync();

            if (!ModelState.IsValid)
            {
                return Page();
            }
            cargo.empresa = user.empresa;
            _context.cargo.Add(cargo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./listCargo");
        }
    }
}
