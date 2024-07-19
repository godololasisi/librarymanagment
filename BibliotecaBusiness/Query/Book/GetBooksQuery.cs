using AutoMapper;
using BibliotecaBusiness.DTOs;
using BibliotecaBusiness.Interfaces;
using BibliotecaDomain.Books;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBusiness.Query.Book
{
    public class GetBooksQuery : IRequest<List<BookDto>>
    {
    }
    public class GetBooksHandler : IRequestHandler<GetBooksQuery, List<BookDto>>
    {
        private IBookRepository _bookRepository;
        private IMapper _mapper;
        public GetBooksHandler(
            IBookRepository bookRepository,
            IMapper mapper
            )
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<List<BookDto>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetListAsync();
            var booksDto = _mapper.Map<List<GetBook>, List<BookDto>>(books);
            return booksDto;
        }
    }
}
