namespace RegistroNotas.Datos.Clases.DAL
{
    using RegistroNotas.IC.DTO.Repositorio;
    using System.Collections.Generic;
    using System.Linq;
    public class AlumnoDAL
    {
        private RepositorioGenerico<Alumno> repositorio;
        private RegistronotasContext context;
        public AlumnoDAL()
        {
            this.context = new RegistronotasContext();
            this.repositorio = new RepositorioGenerico<Alumno>(context);
        }
        public IAlumnoDTO ConsultarPorIdAlumno(int id)
        {
            using (context = new RegistronotasContext())
            {
                var alumno = context.Alumno.Where(p => p.Id == id).FirstOrDefault();
                return alumno;
            }
        }
        public List<IAlumnoDTO> AgregarAlumno(IAlumnoDTO alumno)
        {
            Alumno alumnoDO = new Alumno()
            {
                Email = alumno.Email,
                Nombres = alumno.Nombres,
                DocumentoIdentificacion = alumno.DocumentoIdentificacion,
                PrimerApellido = alumno.PrimerApellido,
                SegundoApellido = alumno.SegundoApellido
            }; using (context = new RegistronotasContext())
            {
                repositorio.Agregar(alumnoDO);
                repositorio.Guardar();
            }
            return BuscarTodosAlumno();
        }
        public List<IAlumnoDTO> EditarAlumno(IAlumnoDTO alumno)
        {
            Alumno alumnoDO = new Alumno()
            {
                Id = alumno.Id,
                Email = alumno.Email,
                Nombres = alumno.Nombres,
                DocumentoIdentificacion = alumno.DocumentoIdentificacion,
                PrimerApellido = alumno.PrimerApellido,
                SegundoApellido = alumno.SegundoApellido
            };

            using (context = new RegistronotasContext())
            {
                repositorio.Editar(alumnoDO);
                repositorio.Guardar();
            }
            return BuscarTodosAlumno();
        }
        public List<IAlumnoDTO> EliminarAlumno(IAlumnoDTO alumno)
        {
            Alumno alumnoDO = new Alumno()
            {
                Id = alumno.Id,
                Email = alumno.Email,
                Nombres = alumno.Nombres,
                DocumentoIdentificacion = alumno.DocumentoIdentificacion,
                PrimerApellido = alumno.PrimerApellido,
                SegundoApellido = alumno.SegundoApellido
            };
            using (context = new RegistronotasContext())
            {
                repositorio.Eliminar(alumnoDO);
                repositorio.Guardar();
            }
            return BuscarTodosAlumno();
            return BuscarTodosAlumno();
        }
        public List<IAlumnoDTO> BuscarTodosAlumno()
        {
            using (context = new RegistronotasContext())
            {
                IQueryable<IAlumnoDTO> Alumno = repositorio.BuscarTodos();

                return Alumno.ToList();
            }
        }
    }
}