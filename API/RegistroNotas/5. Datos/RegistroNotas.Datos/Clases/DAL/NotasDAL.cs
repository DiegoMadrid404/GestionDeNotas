namespace RegistroNotas.Datos.Clases.DAL
{
    using RegistroNotas.Datos.Clases.DO.Consulta;
    using System.Collections.Generic;
    using System.Linq;
    public class NotasDAL
    {
        private RepositorioGenerico<Nota> repositorio;
        private RegistronotasContext context;
        public List<NotaEstudiante> ConsultarNotasPorAlumno()
        {
            using (context = new RegistronotasContext())
            {
                List<NotaEstudiante> NotasPorEstudiante = (from nota in context.Nota
                                                           join alumno in context.Alumno on nota.IdAlumno equals alumno.Id
                                                           join materia in context.Materia on nota.IdMateria equals materia.Id
                                                           select new NotaEstudiante()
                                                           {
                                                               NombreAlumno = alumno.Nombres,
                                                               NombreMateria = materia.Nombre,
                                                               Nota = nota.Nota1
                                                           }).ToList();
                return NotasPorEstudiante;
            }
        }
        public Nota GuardarServicio(Nota nota)
        {
            using (context = new RegistronotasContext())
            {
                repositorio.Agregar(nota);
                repositorio.Guardar();
            }
            return nota;
        }
    }
}