using RegistroNotas.IC.DTO.Consulta;

namespace RegistroNotas.API.Models.Consulta
{
 
    public class NotaPromedioModel : INotaPromedioDTO
    {

        public string Estudiante { get; set; }
        public string Materia { get; set; }
        public decimal Calificacion { get; set; }
    }
}