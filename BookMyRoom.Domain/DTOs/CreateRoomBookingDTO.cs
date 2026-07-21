using System.ComponentModel.DataAnnotations;

namespace BookMyRoom.Domain.DTOs;

public record CreateRoomBookingDTO
(
    [Required (ErrorMessage ="Room id is required")]
     int RoomId,
     string BookedBy,
     DateTime StartTime,
     DateTime EndTime 
);
