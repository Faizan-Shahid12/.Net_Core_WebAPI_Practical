using AutoMapper;
using WebApi_Practice.DTO;
using WebApi_Practice.Models;

namespace WebApi_Practice.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookDTO, Book>().ReverseMap();


            //If Attributes have different name, then we use this
            // If we need to ignore something in mapper, we use Ignore
           // CreateMap<BookDTO, Book>()
             //   .ForMember(Bo => Bo.Id, opt => opt.Ignore())
               // .ForMember(Bo => Bo.Id, opt => opt.MapFrom(boo => boo.Title)).ReverseMap();
        }
           
    }
}
