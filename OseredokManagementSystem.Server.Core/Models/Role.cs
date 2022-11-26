using System.ComponentModel.DataAnnotations;

namespace OseredokManagementSystem.Server.Core.Models
{
    public class Role
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}