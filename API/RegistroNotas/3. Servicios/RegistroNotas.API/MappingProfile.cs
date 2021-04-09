namespace RegistroNotas.API
{
    using AutoMapper;
    using RegistroNotas.API.Models.Repositorio;
    using RegistroNotas.IC.DTO.Repositorio;
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AlumnoModel, IAlumnoDTO>().ReverseMap();
            CreateMap<MateriaModel, IMateriaDTO>().ReverseMap();
        }
    }
}