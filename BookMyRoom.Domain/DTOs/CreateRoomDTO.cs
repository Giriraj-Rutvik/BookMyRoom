namespace BookMyRoom.Domain.DTOs;

public record CreateRoomDTO
(
    string Name,
    string Location,
    int Capacity,
    string? Description
);