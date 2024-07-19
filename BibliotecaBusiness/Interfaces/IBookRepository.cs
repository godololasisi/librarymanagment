using BibliotecaBusiness.DTOs;
using BibliotecaDomain.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBusiness.Interfaces
{
    public interface IBookRepository
    {
        Task<List<GetBook>> GetListAsync();
        Task RegisterBookAsync(RegisterBookDto book);
    }
}
