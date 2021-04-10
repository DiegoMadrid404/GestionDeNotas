namespace RegistroNotas.API.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using RegistroNotas.API.Models.Repositorio;
    using RegistroNotas.Core.Clases.BL;
    using RegistroNotas.IC.DTO.Repositorio;
    using System.Collections.Generic;
    [Route("api/Materia")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        private readonly IMapper _mapper;
        public MateriaController(IMapper mapper)
        {
            _mapper = mapper;
        }
        private MateriaBL negocioMateria = new MateriaBL();

        /// <summary>
        /// Consultar todos los registro de la entidad
        /// </summary>
        /// <returns>
        /// Retorna los registros de la entidad
        /// </returns> 
        [HttpGet]
        public List<MateriaModel> Get()
        {
            List<IMateriaDTO> MateriaBO = negocioMateria.BuscarTodosMateria();
            var response = _mapper.Map<List<MateriaModel>>(MateriaBO);
            return response;

        }
        /// /// <summary>
        /// Consultar un registro especifico de la entidad
        /// </summary>
        ///  /// <param id="id entidad">
        /// <returns>
        /// Retorna el registro solicitado
        /// </returns>
        [HttpGet("{id}")]
        public MateriaModel Get(int id)
        {
            IMateriaDTO MateriaBO = negocioMateria.ConsultarPorIdMateria(id);
            var response = _mapper.Map<MateriaModel>(MateriaBO);
            return response;
        }
        /// <summary>
        /// Guardar registro en la entidad
        /// </summary>
        /// <returns>
        /// Retorna los registros de la entidad
        /// </returns> 
        [HttpPost]
        public List<MateriaModel> Post([FromBody] MateriaModel Materia)
        {
            List<IMateriaDTO> MateriaBO = negocioMateria.AgregarMateria(Materia);
            var response = _mapper.Map<List<MateriaModel>>(MateriaBO);
            return response;
        }
        /// <summary>
        /// Actualizar registro en la entidad
        /// </summary>
        /// <returns>
        /// Retorna los registros de la entidad
        /// </returns> 
        [HttpPut]
        public List<MateriaModel> Put([FromBody] MateriaModel Materia)
        {
            List<IMateriaDTO> MateriaBO = negocioMateria.EditarMateria(Materia);
            var response = _mapper.Map<List<MateriaModel>>(MateriaBO);
            return response;
        }
        /// <summary>
        /// Eliminar un registro especifico
        /// </summary>
        /// <returns>
        /// Retorna los registros de la entidad
        /// </returns> 
        [HttpDelete("{id}")]
        public List<MateriaModel> Delete(int id)
        {
            List<IMateriaDTO> MateriaBO = negocioMateria.EliminarMateria(id);
            var response = _mapper.Map<List<MateriaModel>>(MateriaBO);
            return response;
        }
    }
}