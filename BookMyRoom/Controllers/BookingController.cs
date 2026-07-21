using BookMyRoom.Application.Services.BookingServices;
using BookMyRoom.Application.Services.RoomServices;
using BookMyRoom.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BookMyRoom.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly IBookingService _bookingService;
    public BookingController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBookingAsync(CreateRoomBookingDTO model)
    {
        var booking = await _bookingService.CreateBookingAsync(model);
        return Ok(new {response = booking});
    }

    [HttpGet]
    public async Task<IActionResult> GetBookingByRoomIdAsync(int id)
    {
        var booking = await _bookingService.GetByRoomIdAsync(id);
        if(booking is not null && booking.Any())
        {
            return Ok(new { response = booking });
        }
        return NotFound(new { message = "No booking found for this room" });
    }

    [HttpGet]
    public async Task<IActionResult> GetMyBookingsAsync(string name)
    {
        var myBookings = await _bookingService.GetMyBookingsAsync(name);
        if(myBookings is not null && myBookings.Any())
        {
            return Ok(new { response = myBookings });
        }
        return NotFound(new { message = "Currently you don't have any booking" });
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBookingsAsync()
    {
        var bookings = await _bookingService.GetAllBookings();
        if (bookings is not null && bookings.Any())
        {
            return Ok(new { response = bookings});
        }
        return NotFound(new { message = "Currently not any booking found!" });
    }
}
