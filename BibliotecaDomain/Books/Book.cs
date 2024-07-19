using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDomain.Books
{
    public class Book
    {
        public int Id { get; set; }
        public int CountBooks { get; set; }
        public string? NameBook { get; set; }
        public int IdAuthor { get; set; }
    }
    
    public class GetBook
    {
        public int Id { get; set; }
        public Guid IdentifierBook { get; set; }
        public int CountBooks { get; set; }
        public string? NameBook { get; set; }
        public string? AuthorName { get; set; }
        public bool IsAvailable { get; set; }
    }
}
