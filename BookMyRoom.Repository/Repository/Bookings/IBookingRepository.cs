using BookMyRoom.Domain.DTOs;
using BookMyRoom.Domain.Model;

namespace BookMyRoom.Repository.Repository.Bookings
{
    public interface IBookingRepository
    {
        Task<Booking> CreateAsync(CreateRoomBookingDTO model);
        Task<List<Booking>?> GetAllBookingsAsync();
        Task<List<Booking>?> GetByRoomIdAsync(int id);
        Task<List<Booking>?> GetMyBookingsAsync(string name);
        Task<bool> IsRoomAvailable(int roomId, DateTime startDateTime, DateTime endDateTime);
    }
}