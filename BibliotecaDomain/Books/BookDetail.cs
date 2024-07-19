using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDomain.Books
{
    public class BookDetail
    {
        public int Id { get; set; }
        public Guid IdentifierBook { get; set; }
        public bool IsAvailable { get; set; }
        public int IdBook { get; set; }
    }
}
