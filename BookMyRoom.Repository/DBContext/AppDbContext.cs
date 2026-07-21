using BookMyRoom.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace BookMyRoom.Repository.DBContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Room> Rooms { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Room>()
            .HasIndex(e => e.Name)
            .IsUnique();
    }
}
