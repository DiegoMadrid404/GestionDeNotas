namespace RegistroNotas.Negocio.Clases.BO.Repositorio
{
    using RegistroNotas.IC.DTO.Repositorio;
    public class MateriaBO : IMateriaDTO
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
    }
}