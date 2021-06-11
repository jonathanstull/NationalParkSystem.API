using Microsoft.EntityFrameworkCore;

namespace NationalParkSystem.Models
{
  public class NationalParkSystemContext : DbContext
  {
    public NationalParkSystemContext(DbContextOptions<NationalParkSystemContext> options)
        : base(options)
    {
    }

    public DbSet<NationalPark> NationalParks { get; set; }

    public DbSet<StatePark> StateParks { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<NationalPark>()
          .HasData(
            new NationalPark { NationalParkId = 1, Name = "Mount St. Helens National Volcanic Monument",
                                  Status = "national monument",         LatLong = "46.275181, -122.217252", State = "OR", Visits = 750000,    BusySeason = "summer",                Climate = "6a",   RvServices = true },
            new NationalPark { NationalParkId = 2, Name = "Yosemite National Park",
                                  Status = "national park",             LatLong = "37.748980, -119.587107", State = "CA", Visits = 4586463,   BusySeason = "spring, summer, fall",  Climate = "5b",   RvServices = true },
            new NationalPark { NationalParkId = 3, Name = "Gettysburg National Military Park",
                                  Status = "national military park",    LatLong = "39.811800, -77.2255080", State = "PA", Visits = 950000,    BusySeason = "summer",                Climate = "6b",   RvServices = false },
            new NationalPark { NationalParkId = 4, Name = "Golden Gate National Recreation Area",
                                  Status = "national recreation area",  LatLong = "37.830945, -122.524451", State = "CA", Visits = 12400045,  BusySeason = "all year",              Climate = "10a",  RvServices = true },
            new NationalPark { NationalParkId = 5, Name = "Cape Cod National Seashore",
                                  Status = "national seashore",         LatLong = "41.837530, -69.9725160", State = "MA", Visits = 5230000,   BusySeason = "summer, fall",          Climate = "7a",   RvServices = false }
          );

      builder.Entity<StatePark>()
          .HasData(
            new StatePark { StateParkId = 1, Name = "Smith Rock Monument",
                                  Status = "state monument",            LatLong = "44.365863, -121.137339", State = "OR", Visits = 324000,    BusySeason = "summer",                Climate = "6a",   RvServices = true },
            new StatePark { StateParkId = 2, Name = "Jedediah Smith Redwoods State Park",
                                  Status = "state park",                LatLong = "41.796878, -124.081776", State = "CA", Visits = 23363,     BusySeason = "spring, summer, fall",  Climate = "5b",   RvServices = true },
            new StatePark { StateParkId = 3, Name = "Four Corners Monument",
                                  Status = "Navajo Nation monument",    LatLong = "36.998951, -109.045179", State = "AZ", Visits = 103000,    BusySeason = "summer",                Climate = "6b",   RvServices = false },
            new StatePark { StateParkId = 4, Name = "Big Bend Ranch State Park",
                                  Status = "state park",                LatLong = "29.470494, -103.957694", State = "EW", Visits = 1970045,   BusySeason = "all year",              Climate = "10a",  RvServices = true },
            new StatePark { StateParkId = 5, Name = "Marshall Islands War Memorial Park",
                                  Status = "war memorial",              LatLong = "7.0864070, 171.3736030", State = "EW", Visits = 5230000,   BusySeason = "summer, fall",          Climate = "7a",   RvServices = false }
          );
    }
  }

}