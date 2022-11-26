using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OseredokManagementSystem.Server.Core.Models
{
    public class Admin
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        [Required]
        [ForeignKey(nameof(Gym))]
        public int GymId { get; set; }

        [Required]
        public decimal Salary { get; set; }

        public User User { get; set; }

        public Gym Gym { get; set; }
    }
}