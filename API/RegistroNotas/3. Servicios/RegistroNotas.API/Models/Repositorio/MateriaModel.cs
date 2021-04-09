namespace RegistroNotas.API.Models.Repositorio
{
    using RegistroNotas.IC.DTO.Repositorio;
    using System.ComponentModel.DataAnnotations;
    public class MateriaModel : IMateriaDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El Campo Codigo es Obligatorio")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "El Campo Nombre es Obligatorio")]
        public string Nombre { get; set; }
    }
}