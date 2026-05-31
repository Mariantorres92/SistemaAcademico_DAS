using System.ComponentModel.DataAnnotations;

namespace SistemaAcademico.Models
{
    public class Estudiante
    {
        public int EstudianteID { get; set; }

        [Required(ErrorMessage = "El carnet es obligatorio")]
        [Display(Name = "Carnet")]
        public string Carnet { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "La carrera es obligatoria")]
        [Display(Name = "Carrera")]
        public string Carrera { get; set; }

        [Display(Name = "Activo")]
        public bool Activo { get; set; } = true;

        public ICollection<Inscripcion> Inscripciones { get; set; }
    }
}