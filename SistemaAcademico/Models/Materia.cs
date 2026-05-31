using System.ComponentModel.DataAnnotations;

namespace SistemaAcademico.Models
{
    public class Materia
    {
        public int MateriaID { get; set; }

        [Required]
        [Display(Name = "Código")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Los créditos son obligatorios")]
        [Display(Name = "Créditos")]
        public int Creditos { get; set; }

        [Display(Name = "Activo")]
        public bool Activo { get; set; } = true;

        public int ProfesorID { get; set; }
        public Profesor Profesor { get; set; }

        public ICollection<Inscripcion> Inscripciones { get; set; }
    }
}