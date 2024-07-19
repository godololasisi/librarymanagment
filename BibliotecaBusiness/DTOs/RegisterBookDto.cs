using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBusiness.DTOs
{
    public class RegisterBookDto
    {
        public int CountBooks { get; set; }
        public string? NameBook { get; set; }
        public string? IdAuthor { get; set; }
        public string? DonatedBy { get; set; }
    }
}
