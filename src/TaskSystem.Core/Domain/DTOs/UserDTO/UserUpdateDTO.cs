using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSystem.Core.Domain.DTOs.UserDTO
{
    public record UserUpdateDTO
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
