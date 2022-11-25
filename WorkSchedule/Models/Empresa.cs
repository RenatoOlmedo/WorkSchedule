using System.ComponentModel.DataAnnotations;

namespace WorkSchedule.Models
{
    public class Empresa
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage = "Insira a razão social para cadastrar a empresa")]
        public string razaoSocial { get; set; }
        [Required (ErrorMessage = "Insira o cnpj para cadastrar a empresa")]
        public string cnpj { get; set; }
        public int status { get; set; } = 1;
        public List<Cargo>? cargos { get; set; }
        public List<Escala>? escalas { get; set; }
    }
}
