using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DescubraSeuFuturo.Models
{
    public class Curso
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Plataforma { get; set; }
        public string? Link { get; set; }
        public int? DuracaoHoras { get; set; } 

        public int? TrilhaAprendizadoId { get; set; }

        [ForeignKey("TrilhaAprendizadoId")]
        public TrilhaAprendizado? TrilhaAprendizado { get; set; }
    }
}