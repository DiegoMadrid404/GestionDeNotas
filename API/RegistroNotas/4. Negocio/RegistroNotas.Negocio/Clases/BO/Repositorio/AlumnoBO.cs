namespace RegistroNotas.Negocio.Clases.BO.Repositorio
{
    using RegistroNotas.IC.DTO.Repositorio;

    public class AlumnoBO : IAlumnoDTO
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string DocumentoIdentificacion { get; set; }
        public string Email { get; set; }
    }
}