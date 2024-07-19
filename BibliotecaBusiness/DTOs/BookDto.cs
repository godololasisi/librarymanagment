using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBusiness.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public Guid IdentifierBook { get; set; }
        public int CountBooks { get; set; }
        public string? NameBook { get; set; }
        public string? AuthorName { get; set; }
        public bool IsAvailable { get; set; }
    }
}
