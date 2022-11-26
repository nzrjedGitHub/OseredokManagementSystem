using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OseredokManagementSystem.Server.Core.Models
{
    public class Coach
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        [Required]
        [ForeignKey(nameof(Gym))]
        public int GymId { get; set; }

        [Required]
        public decimal PercentagePerSession { get; set; }

        public ICollection<Client>? Clients { get; set; }

        public ICollection<Session>? Sessions { get; set; }

        public User User { get; set; }

        public Gym Gym { get; set; }
    }
}