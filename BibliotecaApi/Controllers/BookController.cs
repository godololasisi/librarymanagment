using BibliotecaBusiness.Command.Book;
using BibliotecaBusiness.DTOs;
using BibliotecaBusiness.Query;
using BibliotecaBusiness.Query.Book;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaApi.Controllers
{
    public class BookController : RestApiControllerBase
    {
        [HttpGet("list")]
        public async Task<List<BookDto>> GetBooks()
        {
            return await Mediator.Send(new GetBooksQuery() { });
        }

        [HttpPost("register")]
        public async Task<Unit> RegisterBook([FromBody] RegisterBookCommand request)
        {
            return await Mediator.Send(request);
        }
    }
}
