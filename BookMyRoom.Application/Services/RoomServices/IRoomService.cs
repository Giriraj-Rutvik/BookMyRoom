using BookMyRoom.Domain.DTOs;
using BookMyRoom.Domain.Model;

namespace BookMyRoom.Application.Services.RoomServices;

public interface IRoomService
{
    Task<Room> CreateAsync(CreateRoomDTO model);
    Task<bool> DeleteRoomAsync(int id);
    Task<Room?> GetByIdAsync(int id);
    Task<List<Room>?> GetRoomsAsync();
    Task<bool> UpdateRoomDetailsAsync(UpdateRoomDTO model);
}