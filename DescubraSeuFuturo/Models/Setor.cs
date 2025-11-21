using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DescubraSeuFuturo.Models
{
    public class Setor
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }

        public ICollection<Competencia>? Competencias { get; set; }
    }
}