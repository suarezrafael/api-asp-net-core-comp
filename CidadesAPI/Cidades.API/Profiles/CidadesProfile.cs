using AutoMapper;

namespace Cidades.API.Profiles
{
    public class CidadesProfile : Profile
    {
        public CidadesProfile()
        {
            CreateMap<Entities.Cidade, Models.CidadeDto>();

            CreateMap<Models.CidadeParaCriacaoDto, Entities.Cidade>();
        }
    }
}
