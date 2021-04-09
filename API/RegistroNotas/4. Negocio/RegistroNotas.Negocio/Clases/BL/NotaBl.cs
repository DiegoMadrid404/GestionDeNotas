namespace RegistroNotas.Core.Clases.BL
{
    using RegistroNotas.Core.Clases.Excepciones;
    using RegistroNotas.Datos.Clases.DAL;
    using RegistroNotas.IC.DTO.Repositorio;
    using System.Collections.Generic;
    using System.Transactions;
    public class NotaBL
    {
        private NotaDAL NotaDatos = new NotaDAL();
        public List<INotaDTO> AgregarNota(INotaDTO Nota)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                List<INotaDTO> NotaDO = NotaDatos.AgregarNota(Nota);
                transactionScope.Complete();
                return NotaDO;
            }
        }
        public List<INotaDTO> EditarNota(INotaDTO Nota)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                if (!Equals(ConsultarPorIdNota(Nota.Id), null))
                {
                    List<INotaDTO> NotaDO = NotaDatos.EditarNota(Nota);
                    transactionScope.Complete();
                    return NotaDO;
                }
                else
                {
                    throw new BusinessException($"No existe un registro de Nota con el documento {Nota.Id}");
                }
            }
        }
        public List<INotaDTO> EliminarNota(int id)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                INotaDTO NotaDO = NotaDatos.ConsultarPorIdNota(id);
                if (!Equals(NotaDO, null))
                {
                    List<INotaDTO> NotaList = NotaDatos.EliminarNota(NotaDO);
                    transactionScope.Complete();
                    return NotaList;
                }
                else
                {
                    throw new BusinessException($"No existe un registro de Nota con el documento {id}");
                }
            }
        }
        public List<INotaDTO> BuscarTodosNota()
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                List<INotaDTO> NotaDO = NotaDatos.BuscarTodosNota();
                transactionScope.Complete();
                return NotaDO;
            }
        }
        public INotaDTO ConsultarPorIdNota(int id)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                INotaDTO NotaDO = NotaDatos.ConsultarPorIdNota(id);
                transactionScope.Complete();
                return NotaDO;
            }
        }

    }
}