using AutoMapper;
using VehiclesApp.MVC.Models;
using VehiclesApp.Service.Models;

namespace VehiclesApp.MVC
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VehicleMake, VehicleMakeVM>().ReverseMap();
            CreateMap<VehicleModel, VehicleModelVM>().ReverseMap();
        }
    }
}
