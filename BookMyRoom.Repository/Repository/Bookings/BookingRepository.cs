using BookMyRoom.Domain.DTOs;
using BookMyRoom.Domain.Model;
using BookMyRoom.Repository.DBContext;
using Microsoft.EntityFrameworkCore;

namespace BookMyRoom.Repository.Repository.Bookings;

public class BookingRepository : IBookingRepository
{
    private readonly AppDbContext _appDbContext;
    public BookingRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Booking> CreateAsync(CreateRoomBookingDTO model)
    {
        // Map DTO to Entity
        var room = new Booking
        {
            RoomId = model.RoomId,
            BookedBy = model.BookedBy,
            StartTime = model.StartTime,
            EndTime = model.EndTime
        };

        // Add to DbContext
        var entry = await _appDbContext.AddAsync(room);
        await _appDbContext.SaveChangesAsync();

        return entry.Entity;
    }

    public async Task<List<Booking>?> GetByRoomIdAsync(int id)
    {
        //return await _appDbContext.FindAsync<Booking>(id);
        return await _appDbContext.Bookings.Where(x => x.RoomId == id).AsNoTracking().ToListAsync();
    }

    public async Task<List<Booking>?> GetMyBookingsAsync(string name)
    {
        return await _appDbContext.Bookings.Where(x => x.BookedBy == name).AsNoTracking().ToListAsync();
    }

    public async Task<List<Booking>?> GetAllBookingsAsync()
    {
        return await _appDbContext.Bookings.AsNoTracking().ToListAsync();
    }

    public async Task<bool> IsRoomAvailable(int roomId, DateTime startDateTime, DateTime endDateTime)
    {
        var isBooked = await _appDbContext.Bookings
                        .AnyAsync(x =>
                            x.RoomId == roomId &&
                            x.StartTime < endDateTime &&
                            x.EndTime > startDateTime
                        );
        return !isBooked;
    }
}
