using OseredokManagementSystem.Shared.DTOs.ClientPaymentDtos;
using OseredokManagementSystem.Shared.DTOs.CoachDtos;
using OseredokManagementSystem.Shared.DTOs.UserDtos;

namespace OseredokManagementSystem.Shared.DTOs.ClientDtos
{
    public class ClientReadDto
    {
        public int Id { get; set; }

        public UserReadDto User { get; set; }

        public CoachReadDto Coach { get; set; }

        public ClientPaymentReadDto ClientPayment { get; set; }
    }
}