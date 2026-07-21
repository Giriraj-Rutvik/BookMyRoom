using System.ComponentModel.DataAnnotations;

namespace BookMyRoom.Domain.DTOs;

public record UpdateRoomDTO
(
    [Required(ErrorMessage = "Provide Room Id to update")]
    int Id, 
    string? name, string? location, int? capacity, string? description
);