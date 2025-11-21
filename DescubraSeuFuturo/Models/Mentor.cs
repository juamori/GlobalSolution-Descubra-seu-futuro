using System.ComponentModel.DataAnnotations;

namespace DescubraSeuFuturo.Models
{
    public class Mentor
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? AreaAtuacao { get; set; }
        public string? Descricao { get; set; }
        public string? Contato { get; set; }
    }
}