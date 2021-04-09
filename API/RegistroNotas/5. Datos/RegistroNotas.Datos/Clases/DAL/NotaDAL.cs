namespace RegistroNotas.Datos.Clases.DAL
{
    using RegistroNotas.Datos.Clases.DO.Consulta;
    using RegistroNotas.IC.DTO.Repositorio;
    using System.Collections.Generic;
    using System.Linq;
    public class NotaDAL
    {

        private RepositorioGenerico<Nota> repositorio;
        private RegistronotasContext context;
         
        public NotaDAL()
        {
            this.context = new RegistronotasContext();
            this.repositorio = new RepositorioGenerico<Nota>(context);
        }
        public INotaDTO ConsultarPorIdNota(int id)
        {
            using (context = new RegistronotasContext())
            {
                var Nota = context.Nota.Where(p => p.Id == id).FirstOrDefault();
                return Nota;
            }
        }
        public List<INotaDTO> AgregarNota(INotaDTO Nota)
        {
            Nota NotaDO = new Nota()
            {
                IdAlumno = Nota.IdAlumno,
                IdMateria = Nota.IdMateria,
                Calificacion =  Nota.Calificacion
            };

            using (context = new RegistronotasContext())
            {
                repositorio.Agregar(NotaDO);
                repositorio.Guardar();
            }

            return BuscarTodosNota();
        }
        public List<INotaDTO> EditarNota(INotaDTO Nota)
        {
            Nota NotaDO = new Nota()
            {
                Id = Nota.Id,
                IdAlumno = Nota.IdAlumno,
                IdMateria = Nota.IdMateria,
                Calificacion = Nota.Calificacion
            };

            using (context = new RegistronotasContext())
            {
                repositorio.Editar(NotaDO);
                repositorio.Guardar();
            }

            return BuscarTodosNota();
        }
        public List<INotaDTO> EliminarNota(INotaDTO Nota)
        {
            Nota NotaDO = new Nota()
            {
                Id = Nota.Id, 
                IdAlumno = Nota.IdAlumno,
                IdMateria = Nota.IdMateria,
                Calificacion = Nota.Calificacion
            };

            using (context = new RegistronotasContext())
            {
                repositorio.Eliminar(NotaDO);
                repositorio.Guardar();
            }

            return BuscarTodosNota();
        }
        public List<INotaDTO> BuscarTodosNota()
        {
            using (context = new RegistronotasContext())
            {
                IQueryable<INotaDTO> Nota = repositorio.BuscarTodos();

                return Nota.ToList();
            }
        }


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
                                                               Calificacion = nota.Calificacion
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