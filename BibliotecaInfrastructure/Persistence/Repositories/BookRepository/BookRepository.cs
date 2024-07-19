using BibliotecaBusiness.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BibliotecaDomain.Users;
using BibliotecaBusiness.Common.Constants;
using BibliotecaDomain.Books;
using BibliotecaBusiness.DTOs;

namespace BibliotecaInfrastructure.Persistence.Repositories.BookRepository
{
    public class BookRepository : BaseRepository, IBookRepository
    {
        private readonly IConfiguration? _config;
        public BookRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<GetBook>> GetListAsync()
        {
            var books = new List<GetBook>();
            using (var connection = GetConnection(_config))
            {
                SqlCommand cmd = new SqlCommand(StoredProceduresConstants.GetBooksAsync, connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader rdr = await cmd.ExecuteReaderAsync())
                {
                    while (await rdr.ReadAsync())
                    {
                        var book = new GetBook();
                        book.Id = Convert.ToInt32(rdr["Id"]);
                        book.IdentifierBook = Guid.Parse(rdr["IdentifierBook"].ToString()!);
                        book.CountBooks = Convert.ToInt32(rdr["CountBooks"])!;
                        book.NameBook = Convert.ToString(rdr["NameBook"]);
                        book.AuthorName = Convert.ToString(rdr["AuthorName"]);
                        book.IsAvailable = Convert.ToBoolean(rdr["IsAvailable"]);
                        books.Add(book);
                    }
                }
                connection.Close();
            }
            return books;

            
        }

        public async Task RegisterBookAsync(RegisterBookDto book)
        {
            using (var connection = GetConnection(_config))
            {
                SqlCommand cmd = new SqlCommand(StoredProceduresConstants.RegisterBooksAsync, connection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter oParam = cmd.Parameters.AddWithValue("@namebook", book.NameBook);
                oParam = cmd.Parameters.AddWithValue("@idauthor", book.IdAuthor);
                oParam = cmd.Parameters.AddWithValue("@donatedby", book.DonatedBy);
                oParam = cmd.Parameters.AddWithValue("@countbooks", book.CountBooks);

                await cmd.ExecuteNonQueryAsync();

                connection.Close();
            }
        }
    }
}
