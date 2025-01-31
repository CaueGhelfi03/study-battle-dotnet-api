using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace TaskSystem.Domain.Models.User
{
    [Table("Users")]
    public class UserEntity
    {
        [Column("user_id")]
        [Key]
        public Guid Id { get; set; } = new Guid();

        [Column("user_name")]
        [Required]
        public string Name { get; set; }

        [Column("user_email")]
        [Required]
        public string Email { get; set; }

        [Column("user_password")]
        [Required]
        public string UserPassword {  get; set; }
    
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
