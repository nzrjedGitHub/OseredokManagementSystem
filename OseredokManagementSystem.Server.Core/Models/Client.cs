using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OseredokManagementSystem.Server.Core.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        [Required]
        [ForeignKey(nameof(ClientPayment))]
        public int ClientPaymentId { get; set; }

        [Required]
        [ForeignKey(nameof(Coach))]
        public int CoachId { get; set; }

        [Required]
        [ForeignKey(nameof(Gym))]
        public int GymId { get; set; }

        public ICollection<Session>? Sessions { get; set; }

        public User User { get; set; }

        public ClientPayment ClientPayment { get; set; }

        public Coach Coach { get; set; }

        public Gym Gym { get; set; }
    }
}