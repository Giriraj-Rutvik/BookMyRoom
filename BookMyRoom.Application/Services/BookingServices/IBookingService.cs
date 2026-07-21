using BookMyRoom.Domain.DTOs;
using BookMyRoom.Domain.Model;

namespace BookMyRoom.Application.Services.BookingServices
{
    public interface IBookingService
    {
        Task<Booking> CreateBookingAsync(CreateRoomBookingDTO model);
        Task<List<Booking>?> GetAllBookings();
        Task<List<Booking>?> GetByRoomIdAsync(int id);
        Task<List<Booking>?> GetMyBookingsAsync(string name);
    }
}