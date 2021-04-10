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
        // GET: api/<MateriaController>
        [HttpGet]
        public List<MateriaModel> Get()
        {
            List<IMateriaDTO> MateriaBO = negocioMateria.BuscarTodosMateria();
            var response = _mapper.Map<List<MateriaModel>>(MateriaBO);
            return response;

        }
        // GET api/<MateriaController>/5
        [HttpGet("{id}")]
        public MateriaModel Get(int id)
        {
            IMateriaDTO MateriaBO = negocioMateria.ConsultarPorIdMateria(id);
            var response = _mapper.Map<MateriaModel>(MateriaBO);
            return response;
        }
        // POST api/<MateriaController>
        [HttpPost]
        public List<MateriaModel> Post([FromBody] MateriaModel Materia)
        {
            List<IMateriaDTO> MateriaBO = negocioMateria.AgregarMateria(Materia);
            var response = _mapper.Map<List<MateriaModel>>(MateriaBO);
            return response;
        }
        // PUT api/<MateriaController>/5
        [HttpPut]
        public List<MateriaModel> Put([FromBody] MateriaModel Materia)
        {
            List<IMateriaDTO> MateriaBO = negocioMateria.EditarMateria(Materia);
            var response = _mapper.Map<List<MateriaModel>>(MateriaBO);
            return response;
        }
        // DELETE api/<MateriaController>/5
        [HttpDelete("{id}")]
        public List<MateriaModel> Delete(int id)
        {
            List<IMateriaDTO> MateriaBO = negocioMateria.EliminarMateria(id);
            var response = _mapper.Map<List<MateriaModel>>(MateriaBO);
            return response;
        }
    }
}