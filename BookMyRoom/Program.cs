using BookMyRoom.Application.Services.BookingServices;
using BookMyRoom.Application.Services.RoomServices;
using BookMyRoom.Middleware;
using BookMyRoom.Repository.DBContext;
using BookMyRoom.Repository.Repository.Bookings;
using BookMyRoom.Repository.Repository.RoomRepo;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Server=prod-sql-01;Database=BookMyRoom;User Id=sa;Password=P@ssw0rd!Prod2026;TrustServerCertificate=True;";
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

#region Services DI
// Register Application layer services
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IBookingService, BookingService>();
#endregion

#region Repository DI
// Register Repository layer if needed (generic repositories, etc.)
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
#endregion

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
WebApplication app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
