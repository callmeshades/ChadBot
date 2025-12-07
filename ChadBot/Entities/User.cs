using System.ComponentModel.DataAnnotations;

namespace ChadBot.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public ulong DiscordId { get; set; }

        [Required]
        public string Username { get; set; } = default!;

        public DateTime? Birthday { get; set; }
    }
}
