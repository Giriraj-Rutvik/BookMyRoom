using BookMyRoom.Application.Services.RoomServices;
using BookMyRoom.Domain.DTOs;
using BookMyRoom.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookMyRoom.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class RoomController : ControllerBase
{
    private readonly IRoomService _roomService;
    public RoomController(IRoomService roomService)
    {
        _roomService = roomService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateRoomDTO model)
    {
        Room room = await _roomService.CreateAsync(model);

        return Ok(new
        {
            response = room
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        Room? room = await _roomService.GetByIdAsync(id);

        if (room is null)
        {
            return NotFound(new { message = "Room not found" });
        }

        return Ok(new { response = room });
    }

    [HttpPost]
    public async Task<IActionResult> SearchAsync()
    {
        List<Room>? rooms = await _roomService.GetRoomsAsync();
        if (rooms is null)
        {
            return NotFound(new { message = "No room(s) found" });
        }

        return Ok(new { data = rooms, count = rooms.Count });
    }

    [HttpPost]
    public async Task<IActionResult> UpdateRoomDetailsAsync(UpdateRoomDTO model)
    {
        bool response = await _roomService.UpdateRoomDetailsAsync(model);
        if (response)
        {
            return Ok("Room Details updated successfully!");
        }
        else
        {
            return BadRequest("Failed to update Room details!");
        }
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        bool response = await _roomService.DeleteRoomAsync(id);
        if (response)
        {
            return Ok("Room deleted successfully!");
        }
        else
        {
            return BadRequest("Failed to delete Room!");
        }
    }
}
