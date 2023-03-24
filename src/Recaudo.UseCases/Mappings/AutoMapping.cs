using AutoMapper;
using Recaudo.DTOs;
using Recaudo.Entities.POCOs;

namespace Recaudo.UseCases.Mappings
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<AddConteoVehiculoDTO, ConteoVehiculo>().ReverseMap();
            CreateMap<ConteoVehiculo,ConteoVehiculoDTO>().ReverseMap();
            CreateMap<AddRecaudoVehiculoDTO, RecaudoVehiculo>().ReverseMap();
            CreateMap<RecaudoVehiculo, RecaudoVehiculoDTO>().ReverseMap();
        }
    }
}
