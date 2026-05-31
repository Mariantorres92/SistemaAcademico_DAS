using System.ComponentModel.DataAnnotations;
using System.Drawing.Drawing2D;

namespace SistemaAcademico.Models
{
    public class Profesor
    {
        public int ProfesorID { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "La especialidad es obligatoria")]
        [Display(Name = "Especialidad")]
        public string Especialidad { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string Correo { get; set; }

        [Display(Name = "Activo")]
        public bool Activo { get; set; } = true;

        public ICollection<Materia> Materias { get; set; }
    }
}
