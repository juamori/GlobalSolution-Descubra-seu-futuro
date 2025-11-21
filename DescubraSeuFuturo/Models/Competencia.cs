using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DescubraSeuFuturo.Models
{
    public class Competencia
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? NivelDemanda { get; set; }
        public string? Descricao { get; set; }

        public int? SetorId { get; set; }
        
        [ForeignKey("SetorId")]
        public Setor? Setor { get; set; }
    }
}