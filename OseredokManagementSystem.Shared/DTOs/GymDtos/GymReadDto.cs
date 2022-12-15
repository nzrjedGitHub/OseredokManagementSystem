using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OseredokManagementSystem.Shared.DTOs.GymDtos
{
    public class GymReadDto
    {
        public int Id { get; set; }

        public int ClientCapacity { get; set; }

        public string Address { get; set; }
    }
}
