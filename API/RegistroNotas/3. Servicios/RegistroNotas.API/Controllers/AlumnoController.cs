using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RegistroNotas.API.Models.Repositorio;
using RegistroNotas.IC.DTO.Repositorio;
using RegistroNotas.Negocio.Clases.BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RegistroNotas.API.Controllers
{


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
        public AlumnoModel Post([FromBody] AlumnoModel alumno)
        {
            IAlumnoDTO alumnoBO = negocioAlumno.AgregarAlumno(alumno);
            var response = _mapper.Map<AlumnoModel>(alumnoBO);
            return response;
        }

        // PUT api/<AlumnoController>/5
        [HttpPut]
        public AlumnoModel Put(int id, [FromBody] AlumnoModel alumno)
        {
            IAlumnoDTO alumnoBO = negocioAlumno.AgregarAlumno(alumno);
            var response = _mapper.Map<AlumnoModel>(alumnoBO);
            return response;
        }

        // DELETE api/<AlumnoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}