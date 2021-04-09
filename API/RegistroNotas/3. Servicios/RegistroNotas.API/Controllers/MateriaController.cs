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

        // GET: api/<AlumnoController>
        [HttpGet]
        public List<AlumnoModel> Get()
        {
            List<IAlumnoDTO> alumnoBO = negocioAlumno.BuscarTodosAlumno();
            var response = _mapper.Map<List<AlumnoModel>>(alumnoBO);
            return response;
        }
        // GET api/<AlumnoController>/5
        [HttpGet("{id}")]
        public AlumnoModel Get(int id)
        {
            IAlumnoDTO alumnoBO = negocioAlumno.ConsultarPorIdAlumno(id);
            var response = _mapper.Map<AlumnoModel>(alumnoBO);
            return response;
        }
        // POST api/<AlumnoController>
        [HttpPost]
        public List<AlumnoModel> Post([FromBody] AlumnoModel alumno)
        {
            List<IAlumnoDTO> alumnoBO = negocioAlumno.AgregarAlumno(alumno);
            var response = _mapper.Map<List<AlumnoModel>>(alumnoBO);
            return response;
        }
        // PUT api/<AlumnoController>/5
        [HttpPut]
        public List<AlumnoModel> Put([FromBody] AlumnoModel alumno)
        {
            List<IAlumnoDTO> alumnoBO = negocioAlumno.EditarAlumno(alumno);
            var response = _mapper.Map<List<AlumnoModel>>(alumnoBO);
            return response;
        }
        // DELETE api/<AlumnoController>/5
        [HttpDelete("{id}")]
        public List<AlumnoModel> Delete(int id)
        {
            List<IAlumnoDTO> alumnoBO = negocioAlumno.EliminarAlumno(id);
            var response = _mapper.Map<List<AlumnoModel>>(alumnoBO);
            return response;
        }
    }
}