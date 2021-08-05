using AutoMapper;
using Cidades.API.Helpers;

namespace Cidades.API.Profiles
{
    public class ClientesProfile : Profile
    {
        public ClientesProfile()
        {
            CreateMap<Entities.Cliente, Models.ClienteDto>()
             .ForMember(
                dest => dest.Idade,
                opt => opt.MapFrom( src => src.DataDeNascimento.GetCurrentAge())
                
               )
             .ForMember(
                dest => dest.Cidade,
                opt => opt.MapFrom( src => src.Cidade.Nome) 
                );
            

            CreateMap<Models.ClienteParaCriacaoDto, Entities.Cliente>();
            CreateMap<Models.ClienteParaAtualizacaoDto, Entities.Cliente>().ReverseMap();
        }
    }
}
