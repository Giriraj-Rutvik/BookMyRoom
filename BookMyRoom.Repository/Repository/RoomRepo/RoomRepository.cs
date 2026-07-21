using BookMyRoom.Domain.DTOs;
using BookMyRoom.Domain.Model;
using BookMyRoom.Repository.DBContext;
using Microsoft.EntityFrameworkCore;

namespace BookMyRoom.Repository.Repository.RoomRepo;

public class RoomRepository : IRoomRepository
{
    private readonly AppDbContext _appDbContext;
    public RoomRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Room> CreateAsync(Room model)
    {
        // Add to DbContext
        var entry = await _appDbContext.AddAsync(model);
        await _appDbContext.SaveChangesAsync();

        return entry.Entity;
    }

    public async Task<Room?> GetByIdAsync(int id)
    {
        return await _appDbContext.FindAsync<Room>(id);
    }

    public async Task<List<Room>?> GetRoomsAsync()
    {
        return await _appDbContext.Rooms.AsNoTracking().ToListAsync();
    }

    public async Task<bool> SaveChangesAsync()
    {
        await _appDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteRoomAsync(Room room)
    {
        _appDbContext.Rooms.Remove(room);
        await _appDbContext.SaveChangesAsync();
        return true;
    }
}
