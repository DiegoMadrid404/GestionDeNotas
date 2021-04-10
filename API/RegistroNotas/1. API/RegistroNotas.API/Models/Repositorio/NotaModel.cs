namespace RegistroNotas.API.Models.Repositorio
{
    using RegistroNotas.IC.DTO.Repositorio;
    using System.ComponentModel.DataAnnotations;
    public class NotaModel : INotaDTO    {

        public int Id { get; set; }
        [Required(ErrorMessage = "El Campo Id Alumno es Obligatorio")]
        public int IdAlumno { get; set; }
        [Required(ErrorMessage = "El Campo Id Materia es Obligatorio")]
        public int IdMateria { get; set; }
        [Required(ErrorMessage = "El Campo Calificacion es Obligatorio")]
        public decimal Calificacion { get; set; }
    }
}