namespace RegistroNotas.IC.DTO.Repositorio
{
    public interface INotaDTO
    {
        int Id { get; set; }
        int IdAlumno { get; set; }
        int IdMateria { get; set; }

        decimal Calificacion { get; set; } 
    }
}