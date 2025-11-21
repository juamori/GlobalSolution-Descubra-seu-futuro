using System.ComponentModel.DataAnnotations;

namespace DescubraSeuFuturo.Models
{
    public class Empregabilidade
    {
        [Key]
        public int Id { get; set; }
        public string? Area { get; set; }
        public double TaxaCrescimento { get; set; } 
        public string? Fonte { get; set; }
    }
}