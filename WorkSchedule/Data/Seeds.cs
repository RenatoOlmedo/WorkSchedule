using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WorkSchedule.Models;

namespace WorkSchedule.Data
{
    public static class Seeds
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                string[] roles = new string[] { "Admin", "Empresa", "Funcionario" };

                var newrolelist = new List<IdentityRole>();
                foreach (string role in roles)
                {
                    if (!context.Roles.Any(r => r.Name == role))
                    {
                        newrolelist.Add(new IdentityRole(role) { NormalizedName = role.ToUpperInvariant() });
                    }
                }
                await context.Roles.AddRangeAsync(newrolelist);
                await context.SaveChangesAsync();
            }

            using (UserManager<User> _userManager = serviceProvider.GetRequiredService<UserManager<User>>())
            {

                var userlist = new List<User>()
                {
                    new User(){
                        UserName="renato@gmail.com.br",
                        Email="renato@gmail.com.br",
                        nomeCompleto="Renato Ferreira Olmedo",
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                    },
                };


                foreach (var user in userlist)
                {
                    if (!_userManager.Users.Any(r => r.UserName == user.UserName || r.Email == user.Email))
                    {
                        var newuser = user;

                        var result = await _userManager.CreateAsync(newuser, "trlwR62h!powof8Von!+");
                        if (result.Succeeded)
                        {
                            await _userManager.AddToRoleAsync(newuser, "Admin");

                            Claim claim = new Claim("Add", "true", ClaimValueTypes.Boolean);
                            await _userManager.AddClaimAsync(newuser, claim);
                        }

                    }
                }

            }
        }
    }
}
