namespace RegistroNotas.API.Models.Repositorio
{
    using System.ComponentModel.DataAnnotations;
    using RegistroNotas.IC.DTO.Repositorio;

    public class AlumnoModel : IAlumnoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Campo Nombre es Obligatorio")]
        public string Nombres { get; set; }

        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string DocumentoIdentificacion { get; set; }

        //[RegularExpression(@"/^[^\s@]+@[^\s@]+\.[^\s@]+$/", ErrorMessage = "Correo no valido")]
        public string Email { get; set; }
    }
}