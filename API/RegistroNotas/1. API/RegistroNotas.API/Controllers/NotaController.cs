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

        // GET: api/<NotaController>
        [HttpGet]
        public List<NotaModel> Get()
        {
            List<INotaDTO> NotaBO = negocioNota.BuscarTodosNota();
            var response = _mapper.Map<List<NotaModel>>(NotaBO);
            return response;
        }


        // GET api/<NotaController>/5
        [HttpGet("{id}")]
        public NotaModel Get(int id)
        {
            INotaDTO NotaBO = negocioNota.ConsultarPorIdNota(id);
            var response = _mapper.Map<NotaModel>(NotaBO);
            return response;
        }
        // POST api/<NotaController>
        [HttpPost]
        public List<NotaModel> Post([FromBody] NotaModel Nota)
        {
            List<INotaDTO> NotaBO = negocioNota.AgregarNota(Nota);
            var response = _mapper.Map<List<NotaModel>>(NotaBO);
            return response;
        }
        // PUT api/<NotaController>/5
        [HttpPut]
        public List<NotaModel> Put([FromBody] NotaModel Nota)
        {
            List<INotaDTO> NotaBO = negocioNota.EditarNota(Nota);
            var response = _mapper.Map<List<NotaModel>>(NotaBO);
            return response;
        }
        // DELETE api/<NotaController>/5
        [HttpDelete("{id}")]
        public List<NotaModel> Delete(int id)
        {
            List<INotaDTO> NotaBO = negocioNota.EliminarNota(id);
            var response = _mapper.Map<List<NotaModel>>(NotaBO);
            return response;
        }
        // GETNotaPromedio: api/<NotaController>
        [HttpGet]
        [Route("/GETNotaPromedio")]
        public List<NotaPromedioModel> GETNotaPromedio()
        {
            List<INotaPromedioDTO> NotaBO = negocioNota.ConsultarPromedioNota();
            var response = _mapper.Map<List<NotaPromedioModel>>(NotaBO);
            return response;
        }
    }
}