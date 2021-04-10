namespace RegistroNotas.Datos.Clases
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Clase de Repositorio Generico
    /// </summary>
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {
        #region "ATRIBUTOS"

        private T entidad;

        /// <summary>
        /// Contexto para el Repositorio
        /// </summary>
        internal DbContext contexto;

        #endregion "ATRIBUTOS"

        #region "CONSTRUCTORES"

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="contexto">
        /// Contexto de Entity
        /// </param>
        public RepositorioGenerico(DbContext contexto)
        {
            this.contexto = contexto;
        }

        #endregion "CONSTRUCTORES"

        #region "INSERT"

        /// <summary>
        /// Inserta un registro en la base de datos
        /// </summary>
        /// <param name="entidad">
        /// Registro a Insertar
        /// </param>
        public void Agregar(T entidad)
        {
            contexto.Set<T>().Add(entidad);
            this.entidad = entidad;
        }

        #endregion "INSERT"

        #region "UPDATE"

        /// <summary>
        /// Editar un registro en la base de datos
        /// </summary>
        /// <param name="entidad">
        /// Registro a Editar
        /// </param>
        public void Editar(T entidad)
        {
            contexto.Entry(entidad).State = EntityState.Modified;
            this.entidad = entidad;
        }

        #endregion "UPDATE"

        #region "DELETE"

        /// <summary>
        /// Eliminar un registro en la base de datos
        /// </summary>
        /// <param name="entidad">
        /// Registro a Eliminar
        /// </param>
        public void Eliminar(T entidad)
        {
            contexto.Set<T>().Remove(entidad);
            this.entidad = entidad;
        }

        #endregion "DELETE"

        /// <summary>
        /// Consultar todos los registros de la base de datos
        /// </summary>
        /// <returns>
        /// Todos los registros de la entidad
        /// </returns>
        public IQueryable<T> BuscarTodos()
        {
            IQueryable<T> resultado = contexto.Set<T>();
            return resultado;
        }

        /// <summary>
        /// Consultar registros de la base de datos segun filtro
        /// </summary>
        /// <param name="filtro">
        /// filtro de los datos a consultar
        /// </param>
        /// <returns>
        /// </returns>
        public IQueryable<T> BuscarPor(Expression<Func<T, bool>> filtro)
        {
            IQueryable<T> resultado = contexto.Set<T>().Where(filtro);
            return resultado;
        }

        /// <summary>
        /// realiza Commit de la transaccion
        /// </summary>
        public void Guardar()
        {
            contexto.SaveChanges();
        }

        /// <summary>
        /// Realiza commit de forma asincrona de la transacción
        /// </summary>
        public Task GuardarAsync()
        {
            return contexto.SaveChangesAsync();
        }
    }
}