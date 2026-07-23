using BookMyRoom.Domain.DTOs;
using BookMyRoom.Domain.Model;
using BookMyRoom.Repository.Repository.RoomRepo;

namespace BookMyRoom.Application.Services.RoomServices;

public class RoomService : IRoomService
{
    private readonly IRoomRepository _roomRepository;

    public RoomService(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }
    public async Task<Room> CreateAsync(CreateRoomDTO model)
    {
        // Map DTO to Entity
        var room = new Room
        {
            Name = model.Name,
            Location = model.Location,
            Capacity = model.Capacity,
            Description = model.Description
        };

        return await _roomRepository.CreateAsync(room);
    }
    public async Task<Room?> GetByIdAsync(int id) => await _roomRepository.GetByIdAsync(id);
    public async Task<List<Room>?> GetRoomsAsync() => await _roomRepository.GetRoomsAsync();
    public async Task<bool> UpdateRoomDetailsAsync(UpdateRoomDTO model)
    {
        if (model.Id == 0)
            throw new Exception("Invalid id for room!");
        var room = await _roomRepository.GetByIdAsync(model.Id);

        if (room == null)
            throw new Exception("Room not found");

        // Update fields
        if (model.name is not null)
            room.Name = model.name;
        if (model.location is not null)
            room.Location = model.location;
        if (model.capacity is not null)
            room.Capacity = model.capacity.Value;
        if (model.description is not null)
            room.Description = model.description;

        await _roomRepository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteRoomAsync(int id)
    {
        var room = await _roomRepository.GetByIdAsync(id);
        if (room == null)
            throw new Exception("Room not found");

        await _roomRepository.DeleteRoomAsync(room);
        return true;
    }
}
