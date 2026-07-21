using System.ComponentModel.DataAnnotations;

namespace BookMyRoom.Domain.Model;

public class Room
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;

    public int Capacity { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
