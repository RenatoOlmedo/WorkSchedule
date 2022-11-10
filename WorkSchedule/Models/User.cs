using Microsoft.AspNetCore.Identity;

namespace WorkSchedule.Models
{
    public class User : IdentityUser
    {
        public string nomeCompleto { get; set; }
        public int status { get; set; } = 1;
        public Empresa? empresa { get; set; }
        public int? cargaHorariaDiaria { get; set; }
        public int? horasDescanso { get; set; }
        public string? tipoEscala { get; set; }
    }
}
