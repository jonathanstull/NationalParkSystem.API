using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NationalParkSystem.Entities;

namespace NationalParkSystem.Helpers
{
  public class DataContext : DbContext
  {
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
      options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
    }

    public DbSet<User> Users { get; set; }
  }
}