namespace RegistroNotas.IC.DTO.Repositorio
{
    public interface IAlumnoDTO
    {
        int Id { get; set; }
        string Nombres { get; set; }
        string PrimerApellido { get; set; }
        string SegundoApellido { get; set; }
        string DocumentoIdentificacion { get; set; }
        string Email { get; set; }
    }
}