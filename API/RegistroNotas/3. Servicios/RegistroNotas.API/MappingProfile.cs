using AutoMapper;
using RegistroNotas.API.Models.Repositorio;
using RegistroNotas.IC.DTO.Repositorio;

namespace RegistroNotas.API
{
    internal class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<AlumnoModel, IAlumnoDTO>().ReverseMap();
        }
    }
}