namespace OseredokManagementSystem.Shared.DTOs.ClientPaymentDtos
{
    public class ClientPaymentReadDto
    {
        public int Id { get; set; }

        public decimal PaymentPerSession { get; set; }

        public decimal Balance { get; set; }

        public decimal LastPaymentSum { get; set; }

        public DateTime LastPaymentDate { get; set; }
    }
}