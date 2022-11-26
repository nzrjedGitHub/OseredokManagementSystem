namespace OseredokManagementSystem.Shared.DTOs.ClientDtos
{
    public class ClientCreateDto
    {
        public int UserId { get; set; }

        public int CoachId { get; set; }

        public int GymId { get; set; }

        public decimal PaymentPerSession { get; set; }
    }
}