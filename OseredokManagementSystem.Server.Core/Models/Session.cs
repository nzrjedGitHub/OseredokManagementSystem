using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OseredokManagementSystem.Server.Core.Models
{
    public class Session
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }

        [Required]
        [ForeignKey(nameof(Coach))]
        public int CoachId { get; set; }

        [Required]
        [ForeignKey(nameof(Gym))]
        public int GymId { get; set; }

        [Required]
        [ForeignKey(nameof(SessionStatus))]
        public int SessionStatusId { get; set; }

        [Required]
        public DateTime SessionDate { get; set; }

        public Client Client { get; set; }

        public Coach Coach { get; set; }

        public Gym Gym { get; set; }

        public SessionStatus SessionStatus { get; set; }
    }
}