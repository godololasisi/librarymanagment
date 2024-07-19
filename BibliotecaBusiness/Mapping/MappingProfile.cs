using AutoMapper;
using BibliotecaBusiness.Command.Book;
using BibliotecaBusiness.DTOs;
using BibliotecaDomain.Books;
using BibliotecaDomain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBusiness.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<BookDto, GetBook>().ReverseMap();
            CreateMap<RegisterBookCommand, RegisterBookDto>().ReverseMap();
        }
    }
}
