using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WorkSchedule.Models
{
    public class Cargo
    {
        [Key]
        public int id { get; set; }
        public string? nomeCargo { get; set; }
        public string? tipoEscala { get; set; }
        public int? Trabalho { get; set; }
        public int? Descanso { get; set; }
        public int status { get; set; } = 1;
        public Empresa empresa { get; set; }
    }
}
