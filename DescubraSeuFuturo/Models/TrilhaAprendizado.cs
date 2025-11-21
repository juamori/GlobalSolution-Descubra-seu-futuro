using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DescubraSeuFuturo.Models
{
    public class TrilhaAprendizado
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }

        public int? CompetenciaId { get; set; }

        [ForeignKey("CompetenciaId")]
        public Competencia? Competencia { get; set; }

        public ICollection<Curso>? Cursos { get; set; }
    }
}