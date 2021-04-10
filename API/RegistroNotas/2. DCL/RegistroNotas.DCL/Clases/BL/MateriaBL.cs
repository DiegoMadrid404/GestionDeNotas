namespace RegistroNotas.Core.Clases.BL
{
    using RegistroNotas.Core.Clases.Excepciones;
    using RegistroNotas.Datos.Clases.DAL;
    using RegistroNotas.IC.DTO.Repositorio;
    using System.Collections.Generic;
    using System.Transactions;
    public class MateriaBL
    {
        private MateriaDAL MateriaDatos = new MateriaDAL();
        public List<IMateriaDTO> AgregarMateria(IMateriaDTO Materia)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                List<IMateriaDTO> MateriaDO = MateriaDatos.AgregarMateria(Materia);
                transactionScope.Complete();
                return MateriaDO;
            }
        }
        public List<IMateriaDTO> EditarMateria(IMateriaDTO Materia)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                if (!Equals(ConsultarPorIdMateria(Materia.Id), null))
                {
                    List<IMateriaDTO> MateriaDO = MateriaDatos.EditarMateria(Materia);
                    transactionScope.Complete();
                    return MateriaDO;
                }
                else
                {
                    throw new BusinessException($"No existe un registro de Materia con el Id {Materia.Id}");
                }
            }
        }
        public List<IMateriaDTO> EliminarMateria(int id)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                IMateriaDTO MateriaDO = MateriaDatos.ConsultarPorIdMateria(id);
                if (!Equals(MateriaDO, null))
                {
                    List<IMateriaDTO> MateriaList = MateriaDatos.EliminarMateria(MateriaDO);
                    transactionScope.Complete();
                    return MateriaList;
                }
                else
                {
                    throw new BusinessException($"No existe un registro de Materia con el Id {id}");
                }
            }
        }
        public List<IMateriaDTO> BuscarTodosMateria()
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                List<IMateriaDTO> MateriaDO = MateriaDatos.BuscarTodosMateria();
                transactionScope.Complete();
                return MateriaDO;
            }
        }
        public IMateriaDTO ConsultarPorIdMateria(int id)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                IMateriaDTO MateriaDO = MateriaDatos.ConsultarPorIdMateria(id);
                transactionScope.Complete();
                return MateriaDO;
            }
        }

    }
}