using System.Collections.Generic;
using System.Transactions;
using RegistroNotas.Datos.Clases.DAL;
using RegistroNotas.IC.DTO.Repositorio;

namespace RegistroNotas.Negocio.Clases.BL
{
    public class AlumnoBL
    {
        private AlumnoDAL alumnoDatos = new AlumnoDAL();

        public IAlumnoDTO AgregarAlumno(IAlumnoDTO alumno)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                IAlumnoDTO alumnoDO = alumnoDatos.AgregarAlumno(alumno);
                transactionScope.Complete();
                return alumnoDO;
            }
        }
        public IAlumnoDTO ModificarAlumno(IAlumnoDTO alumno)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                IAlumnoDTO alumnoDO = alumnoDatos.AgregarAlumno(alumno);
                transactionScope.Complete();
                return alumnoDO;
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