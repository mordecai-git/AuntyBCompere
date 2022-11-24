using AuntyBCompere.Models.Data;

using Microsoft.EntityFrameworkCore;

namespace AuntyBCompere.Data
{
    public class AuntyBCompereContext : DbContext
    {
        public AuntyBCompereContext (DbContextOptions<AuntyBCompereContext> options)
            : base(options)
        {
        }

        public DbSet<Testimonial> Testimonials { get; set; } 
        public DbSet<User> Users { get; set; } 
        public DbSet<Service> Services { get; set; } 
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingService> BookingServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Testimonial>().ToTable("Testimonial");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Service>().ToTable("Service");
            modelBuilder.Entity<Gallery>().ToTable("Gallery");
            modelBuilder.Entity<Booking>().ToTable("Booking");

            modelBuilder.Entity<BookingService>()
                .ToTable("BookingService")
                .HasKey(x => new {x.BookingId, x.ServiceId});

            //modelBuilder.Entity<BookingService>()
            //    .HasOne(pt => pt.Booking)
            //    .WithMany(p => p.BookingService)
            //    .HasFo
        }
    }
}
