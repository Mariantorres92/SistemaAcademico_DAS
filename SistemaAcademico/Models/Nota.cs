using System.ComponentModel.DataAnnotations;

namespace SistemaAcademico.Models
{
    public class Nota
    {
        public int NotaID { get; set; }

        [Display(Name = "Nota 1")]
        [Range(0, 10)]
        public decimal? Nota1 { get; set; }

        [Display(Name = "Nota 2")]
        [Range(0, 10)]
        public decimal? Nota2 { get; set; }

        [Display(Name = "Nota Final")]
        public decimal? NotaFinal { get; set; }

        public int InscripcionID { get; set; }
        public Inscripcion Inscripcion { get; set; }
    }
}