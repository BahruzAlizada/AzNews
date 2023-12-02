using AutoMapper;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;

namespace DataAccessLayer.Mappers.AutoMapper
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<Category,CategoryDto>().ReverseMap();
            CreateMap<Author,AuthorDto>().ReverseMap();
            CreateMap<Blog,BlogDto>().ReverseMap();
        }
    }
}
