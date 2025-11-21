using System.ComponentModel.DataAnnotations;

namespace DescubraSeuFuturo.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? ObjetivoCarreira { get; set; }
        public string? SenhaHash { get; set; } 
    }
}