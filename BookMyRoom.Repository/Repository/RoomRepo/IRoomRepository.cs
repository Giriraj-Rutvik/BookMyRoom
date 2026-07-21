using BookMyRoom.Domain.DTOs;
using BookMyRoom.Domain.Model;

namespace BookMyRoom.Repository.Repository.RoomRepo;

public interface IRoomRepository
{
    Task<Room> CreateAsync(Room model);
    Task<bool> DeleteRoomAsync(Room room);
    Task<Room?> GetByIdAsync(int id);
    Task<List<Room>?> GetRoomsAsync();
    Task<bool> SaveChangesAsync();
}