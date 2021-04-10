namespace RegistroNotas.API.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using RegistroNotas.API.Models.Repositorio;
    using RegistroNotas.Core.Clases.BL;
    using RegistroNotas.IC.DTO.Repositorio;
    using System.Collections.Generic;
    [Route("api/Alumno")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly IMapper _mapper;
        public AlumnoController(IMapper mapper)
        {
            _mapper = mapper;
        }
        private AlumnoBL negocioAlumno = new AlumnoBL();

        /// <summary>
        /// Consultar todos los registro de la entidad
        /// </summary>
        /// <returns>
        /// Retorna los registros de la entidad
        /// </returns> 
        [HttpGet]
        public List<AlumnoModel> Get()
        {
            List<IAlumnoDTO> alumnoBO = negocioAlumno.BuscarTodosAlumno();
            var response = _mapper.Map<List<AlumnoModel>>(alumnoBO);
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
        public AlumnoModel Get(int id)
        {
            IAlumnoDTO alumnoBO = negocioAlumno.ConsultarPorIdAlumno(id);
            var response = _mapper.Map<AlumnoModel>(alumnoBO);
            return response;
        }
        /// <summary>
        /// Guardar registro en la entidad
        /// </summary>
        /// <returns>
        /// Retorna los registros de la entidad
        /// </returns> 
        [HttpPost]
        public List<AlumnoModel> Post([FromBody] AlumnoModel alumno)
        {
            List<IAlumnoDTO> alumnoBO = negocioAlumno.AgregarAlumno(alumno);
            var response = _mapper.Map<List<AlumnoModel>>(alumnoBO);
            return response;
        }
        /// <summary>
        /// Actualizar registro en la entidad
        /// </summary>
        /// <returns>
        /// Retorna los registros de la entidad
        /// </returns> 
        [HttpPut]
        public List<AlumnoModel> Put([FromBody] AlumnoModel alumno)
        {
            List<IAlumnoDTO> alumnoBO = negocioAlumno.EditarAlumno(alumno);
            var response = _mapper.Map<List<AlumnoModel>>(alumnoBO);
            return response;
        }
        /// <summary>
        /// Eliminar un registro especifico
        /// </summary>
        /// <returns>
        /// Retorna los registros de la entidad
        /// </returns> 
        [HttpDelete("{id}")]
        public List<AlumnoModel> Delete(int id)
        {
            List<IAlumnoDTO> alumnoBO = negocioAlumno.EliminarAlumno(id);
            var response = _mapper.Map<List<AlumnoModel>>(alumnoBO);
            return response;
        }
    }
}