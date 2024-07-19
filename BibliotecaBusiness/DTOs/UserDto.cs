using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBusiness.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? Names { get; set; }
        public string? LastName { get; set; }
        public string? IdentificationNumber { get; set; }
        public int PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public string? Email { get; set; }
        public string? DescriptionRole { get; set; }
    }
}
