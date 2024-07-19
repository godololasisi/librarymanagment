using BibliotecaBusiness.DTOs;
using BibliotecaBusiness.Query;
using BibliotecaBusiness.Query.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaApi.Controllers
{
    public class UsuarioController : RestApiControllerBase
    {
        [HttpGet("list")]
        public async Task<List<UserDto>> GetUsers()
        {
            return await Mediator.Send(new GetUserQuery() { });
        }
    }
}
