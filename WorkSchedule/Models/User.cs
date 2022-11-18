using Microsoft.AspNetCore.Identity;

namespace WorkSchedule.Models
{
    public class User : IdentityUser
    {
        public string nomeCompleto { get; set; }
        public int status { get; set; } = 1;
        public Empresa? empresa { get; set; }
        public Cargo? cargo { get; set; }
    }
}
