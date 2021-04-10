namespace RegistroNotas.Datos.Clases
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface de Repositorio Generico
    /// </summary>
    public interface IRepositorioGenerico<T>
    {
        /// <summary>
        /// Consultar todos los registros de la base de datos
        /// </summary>
        /// <returns>
        /// Todos los registros de la entidad
        /// </returns>
        IQueryable<T> BuscarTodos();

        /// <summary>
        /// Consultar registros de la base de datos segun filtro
        /// </summary>
        /// <param name="filtro">
        /// filtro de los datos a consultar
        /// </param>
        /// <returns>
        /// </returns>
        IQueryable<T> BuscarPor(Expression<Func<T, bool>> filtro);

        /// <summary>
        /// Inserta un registro en la base de datos
        /// </summary>
        /// <param name="entidad">
        /// Registro a Insertar
        /// </param>
        void Agregar(T entidad);

        /// <summary>
        /// Eliminar un registro en la base de datos
        /// </summary>
        /// <param name="entidad">
        /// Registro a Eliminar
        /// </param>
        void Eliminar(T entidad);

        /// <summary>
        /// Editar un registro en la base de datos
        /// </summary>
        /// <param name="entidad">
        /// Registro a Editar
        /// </param>
        void Editar(T entidad);

        /// <summary>
        /// realiza Commit de la transaccion
        /// </summary>
        void Guardar();

        /// <summary>
        /// Realiza commit de forma asincrona de la transacción
        /// </summary>
        Task GuardarAsync();
    }
}