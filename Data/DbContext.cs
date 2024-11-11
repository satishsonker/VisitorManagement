using Microsoft.EntityFrameworkCore;
using VisitorManagement.DataModels;

namespace VisitorManagement.Data
{
    public class VisitorManagementDbContext : DbContext
    {
        public VisitorManagementDbContext(DbContextOptions<VisitorManagementDbContext> options) : base(options) { }

        public DbSet<GovernmentIdType> GovernmentIdTypes { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<TimeSlotMapping> TimeSlotMappings { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<PropertyImage> PropertyImages { get; set; }
        public DbSet<HallImage> HallImages { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<HallAmenityMapper> HallAmenityMappers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GovernmentIdType>().HasData(
                new GovernmentIdType { Id = 1, Name = "Passport" },
                new GovernmentIdType { Id = 2, Name = "Driver's License" },
                new GovernmentIdType { Id = 3, Name = "National ID" },
                new GovernmentIdType { Id = 4, Name = "Aadhar" },
                new GovernmentIdType { Id = 5, Name = "PAN Card" },
                new GovernmentIdType { Id = 6, Name = "Voter Card" },
                new GovernmentIdType { Id = 7, Name = "Rasan Card" },
                new GovernmentIdType { Id = 8, Name = "Bank Passbook" }
            );
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added && e.Entity is BaseDataModel);

            foreach (var entry in entries)
            {
                if (entry.Entity is GovernmentIdType govType)
                {
                    govType.CreatedAt = DateTime.UtcNow;
                }
                else if (entry.Entity is Visitor visitor)
                {
                    visitor.CreatedAt = DateTime.UtcNow;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
