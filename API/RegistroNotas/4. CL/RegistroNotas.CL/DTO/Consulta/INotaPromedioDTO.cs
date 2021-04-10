namespace RegistroNotas.IC.DTO.Consulta
{
    public interface INotaPromedioDTO
    {
        string Estudiante { get; set; }
        string Materia { get; set; }
        decimal Calificacion { get; set; }
    }
}