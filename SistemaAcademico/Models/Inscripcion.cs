using System.ComponentModel.DataAnnotations;

namespace SistemaAcademico.Models
{
    public class Inscripcion
    {
        public int InscripcionID { get; set; }

        [Required]
        [Display(Name = "Ciclo")]
        public string Ciclo { get; set; }

        [Display(Name = "Fecha de Inscripción")]
        public DateTime FechaInscripcion { get; set; } = DateTime.Now;

        public int EstudianteID { get; set; }
        public Estudiante Estudiante { get; set; }

        public int MateriaID { get; set; }
        public Materia Materia { get; set; }

        public ICollection<Nota> Notas { get; set; }
    }
}