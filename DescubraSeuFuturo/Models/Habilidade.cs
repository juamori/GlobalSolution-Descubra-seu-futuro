using System.ComponentModel.DataAnnotations;

namespace DescubraSeuFuturo.Models
{
    public class Habilidade
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Tipo { get; set; } 
        public string? Descricao { get; set; }
    }
}