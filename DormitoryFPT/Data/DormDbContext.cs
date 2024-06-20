using DormitoryFPT.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DormitoryFPT.Data
{
    public class DormDbContext : DbContext
    {
        public DormDbContext(DbContextOptions<DormDbContext> options) : base(options)
        {
        }

        public DbSet<Dorm> Dorms { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Room> Rooms { get; set; }


    }
}
