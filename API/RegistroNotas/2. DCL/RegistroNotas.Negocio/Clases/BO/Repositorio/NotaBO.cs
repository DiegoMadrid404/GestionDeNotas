namespace RegistroNotas.Negocio.Clases.BO.Repositorio
{
    using RegistroNotas.IC.DTO.Repositorio;
    public class NotaBO : INotaDTO
    {
        public int Id { get; set; }
        public int IdAlumno { get; set; }
        public int IdMateria { get; set; }
        public decimal Calificacion { get; set; }
    }
}