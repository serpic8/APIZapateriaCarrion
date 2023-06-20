using AutoMapper;
using ZapateriaAPI.Models;
using ZapateriaAPI.Models.Dto;

namespace ZapateriaAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Products, ProductsDto>();
            CreateMap<Products, Products>();

            CreateMap<Products, ProductsCreateDto>().ReverseMap();
            CreateMap<Products, ProductsUpdateDto>().ReverseMap();

            CreateMap<Sales, SalesDto>();
            CreateMap<Sales, Sales>();

            CreateMap<Sales, SalesCreateDto>();
            CreateMap<Sales, SalesUpdateDto>();
        }
    }
}
