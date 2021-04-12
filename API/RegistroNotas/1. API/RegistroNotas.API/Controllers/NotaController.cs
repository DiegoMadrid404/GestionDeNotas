namespace RegistroNotas.API.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using RegistroNotas.API.Models.Consulta;
    using RegistroNotas.API.Models.Repositorio;
    using RegistroNotas.Core.Clases.BL;
    using RegistroNotas.IC.DTO.Consulta;
    using RegistroNotas.IC.DTO.Repositorio;
    using System.Collections.Generic;
    [Route("api/Nota")]
    [ApiController]
    public class NotaController : ControllerBase
    {
        private readonly IMapper _mapper;
        public NotaController(IMapper mapper)
        {
            _mapper = mapper;
        }
        private NotaBL negocioNota = new NotaBL();

        /// <summary>
        /// Consultar todos los registro de la entidad
        /// </summary>
        /// <returns>
        /// Retorna los registros de la entidad
        /// </returns> 
        [HttpGet]
        public List<NotaModel> Get()
        {
            List<INotaDTO> NotaBO = negocioNota.BuscarTodosNota();
            var response = _mapper.Map<List<NotaModel>>(NotaBO);
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
        public NotaModel Get(int id)
        {
            INotaDTO NotaBO = negocioNota.ConsultarPorIdNota(id);
            var response = _mapper.Map<NotaModel>(NotaBO);
            return response;
        }
        /// <summary>
        /// Guardar registro en la entidad
        /// </summary>
        /// <returns>
        /// Retorna los registros de la entidad
        /// </returns> 
        [HttpPost]
        public List<NotaModel> Post([FromBody] NotaModel Nota)
        {
            List<INotaDTO> NotaBO = negocioNota.AgregarNota(Nota);
            var response = _mapper.Map<List<NotaModel>>(NotaBO);
            return response;
        }
        /// <summary>
        /// Actualizar registro en la entidad
        /// </summary>
        /// <returns>
        /// Retorna los registros de la entidad
        /// </returns> 
        [HttpPut]
        public List<NotaModel> Put([FromBody] NotaModel Nota)
        {
            List<INotaDTO> NotaBO = negocioNota.EditarNota(Nota);
            var response = _mapper.Map<List<NotaModel>>(NotaBO);
            return response;
        }
        /// <summary>
        /// Eliminar un registro especifico
        /// </summary>
        /// <returns>
        /// Retorna los registros de la entidad
        /// </returns> 
        [HttpDelete("{id}")]
        public List<NotaModel> Delete(int id)
        {
            List<INotaDTO> NotaBO = negocioNota.EliminarNota(id);
            var response = _mapper.Map<List<NotaModel>>(NotaBO);
            return response;
        }
        /// <summary>
        /// Consultar notas promedio de estudiantes por materia
        /// </summary>
        /// <returns>
        /// Retorna los registros materias estudiantes y nota promedio
        /// </returns> 
        [HttpGet]
        [Route("GETNotaPromedio")]
        public List<NotaPromedioModel> GETNotaPromedio()
        {
            List<INotaPromedioDTO> NotaBO = negocioNota.ConsultarPromedioNota();
            var response = _mapper.Map<List<NotaPromedioModel>>(NotaBO);
            return response;
        }
    }
}