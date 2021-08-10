using AutoMapper;
using sanaTest.Models;

namespace sanaTest.DTOs
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();
        }
    }
}
