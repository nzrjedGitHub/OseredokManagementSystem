using System.ComponentModel.DataAnnotations;

namespace OseredokManagementSystem.Server.Core.Models
{
    public class ClientPayment
    {
        public int Id { get; set; }

        [Required]
        public decimal PaymentPerSession { get; set; }

        [Required]
        public decimal Balance { get; set; }

        [Required]
        public decimal LastPaymentSum { get; set; }

        public DateTime LastPaymentDate { get; set; }
    }
}