using RegistroNotas.IC.DTO.Repositorio;
using System.Collections.Generic;
using System.Linq;

namespace RegistroNotas.Datos.Clases.DAL
{
    public class MateriaDAL
    {
        private RepositorioGenerico<Materia> repositorio;
        private RegistronotasContext context;

        public MateriaDAL()
        {
            this.context = new RegistronotasContext();
            this.repositorio = new RepositorioGenerico<Materia>(context);
        }


        public IMateriaDTO ConsultarPorIdMateria(int id)
        {
            using (context = new RegistronotasContext())
            {
                var Materia = context.Materia.Where(p => p.Id == id).FirstOrDefault();
                return Materia;
            }
        }

        public List<IMateriaDTO> AgregarMateria(IMateriaDTO Materia)
        {
            Materia MateriaDO = new Materia()
            {
                Codigo = Materia.Codigo,
                Nombre = Materia.Nombre             
            };

            using (context = new RegistronotasContext())
            {
                repositorio.Agregar(MateriaDO);
                repositorio.Guardar();
            }

            return BuscarTodosMateria();
        }
        public List<IMateriaDTO> EditarMateria(IMateriaDTO Materia)
        {
            Materia MateriaDO = new Materia()
            {
                Id = Materia.Id,
                Codigo = Materia.Codigo,
                Nombre = Materia.Nombre
            };

            using (context = new RegistronotasContext())
            {
                repositorio.Editar(MateriaDO);
                repositorio.Guardar();
            }

            return BuscarTodosMateria();
        }
        public List<IMateriaDTO> EliminarMateria(IMateriaDTO Materia)
        {
            Materia MateriaDO = new Materia()
            {
                Id = Materia.Id,
                Codigo = Materia.Codigo,
                Nombre = Materia.Nombre
            };

            using (context = new RegistronotasContext())
            {
                repositorio.Eliminar(MateriaDO);
                repositorio.Guardar();
            }

            return BuscarTodosMateria();
        }
        public List<IMateriaDTO> BuscarTodosMateria()
        {
            using (context = new RegistronotasContext())
            {
                IQueryable<IMateriaDTO> Materia = repositorio.BuscarTodos();

                return Materia.ToList();
            }
        }


    }
}