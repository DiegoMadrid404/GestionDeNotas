using System.Collections.Generic;
using System.Transactions;
using RegistroNotas.Core.Clases.Excepciones;
using RegistroNotas.Datos.Clases.DAL;
using RegistroNotas.IC.DTO.Repositorio;

namespace RegistroNotas.Core.Clases.BL
{
    public class AlumnoBL
    {
        private AlumnoDAL alumnoDatos = new AlumnoDAL();

        public List<IAlumnoDTO> AgregarAlumno(IAlumnoDTO alumno)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                List<IAlumnoDTO> alumnoDO = alumnoDatos.AgregarAlumno(alumno);
                transactionScope.Complete();
                return alumnoDO;
            }
        }
        public List<IAlumnoDTO> EditarAlumno(IAlumnoDTO alumno)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                if (!Equals(ConsultarPorIdAlumno(alumno.Id), null))
                {
                    List<IAlumnoDTO> alumnoDO = alumnoDatos.EditarAlumno(alumno);
                    transactionScope.Complete();
                    return alumnoDO;
                }
                else
                {
                    throw new BusinessException($"No existe un registro de alumno con el documento {alumno.Id}");
                }
            }
        }
        public List<IAlumnoDTO> EliminarAlumno(int id)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                IAlumnoDTO alumnoDO = alumnoDatos.ConsultarPorIdAlumno(id);
                if (!Equals(alumnoDO, null))
                {
                    List<IAlumnoDTO> alumnoList = alumnoDatos.EliminarAlumno(alumnoDO);
                    transactionScope.Complete();
                    return alumnoList;
                }
                else
                {
                    throw new BusinessException($"No existe un registro de alumno con el documento {id}");
                }
            }
        }

       
        public List<IAlumnoDTO> BuscarTodosAlumno()
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                List<IAlumnoDTO> alumnoDO = alumnoDatos.BuscarTodosAlumno();
                transactionScope.Complete();
                return alumnoDO;
            }
        }

        public IAlumnoDTO ConsultarPorIdAlumno(int id)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                IAlumnoDTO alumnoDO = alumnoDatos.ConsultarPorIdAlumno(id);
                transactionScope.Complete();
                return alumnoDO;
            }
        }

    }
}