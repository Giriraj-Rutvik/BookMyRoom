using BookMyRoom.Domain.DTOs;
using BookMyRoom.Domain.Model;
using BookMyRoom.Repository.Repository.Bookings;
using BookMyRoom.Repository.Repository.RoomRepo;
using Microsoft.Data.SqlClient.DataClassification;

namespace BookMyRoom.Application.Services.BookingServices;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IRoomRepository _roomRepository;

    public BookingService(IBookingRepository bookingRepository, IRoomRepository roomRepository)
    {
        _bookingRepository = bookingRepository;
        _roomRepository = roomRepository;
    }

    public async Task<Booking> CreateBookingAsync(CreateRoomBookingDTO model)
    {
        await ValidateBookingAsync(model.RoomId, model.StartTime, model.EndTime);
        return await _bookingRepository.CreateAsync(model);
    }
    public async Task<List<Booking>?> GetByRoomIdAsync(int id) => await _bookingRepository.GetByRoomIdAsync(id);
    public async Task<List<Booking>?> GetMyBookingsAsync(string name) => await _bookingRepository.GetMyBookingsAsync(name);
    public async Task<List<Booking>?> GetAllBookings() => await _bookingRepository.GetAllBookingsAsync();

    #region Private Methods
    private async Task ValidateBookingAsync(int roomId, DateTime startDateTime, DateTime endDateTime)
    {
        var room = await _roomRepository.GetByIdAsync(roomId);
        if (room is null)
        {
            throw new Exception("Room not found");
        }
        if (!await _bookingRepository.IsRoomAvailable(roomId, startDateTime, endDateTime))
        {
            throw new Exception("Room is already booked for this time period");
        }
    }
    #endregion
}
