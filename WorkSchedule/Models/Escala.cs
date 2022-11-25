using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WorkSchedule.Models
{
    public class Escala
    {
        [Key]
        public int id { get; set; }
        public int? idPessoaEscala { get; set; }
        public int? mes { get; set; }
        public User? usuario { get; set; }
        public Empresa? empresa { get; set; }
    }
}
