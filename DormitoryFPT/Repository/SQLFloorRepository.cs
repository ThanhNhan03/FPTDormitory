using DormitoryFPT.Data;
using DormitoryFPT.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DormitoryFPT.Repository
{
    public class SQLFloorRepository : IFloorRepository
    {
        private readonly DormDbContext context;
        public SQLFloorRepository(DormDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Floor>> GetAllFloors()
        {
            return await context.Floors
                .Include(f => f.Houses)  // Include the House
                .ToListAsync();
        }

        public async Task<Floor> GetFloorById(Guid id)
        {
            return await context.Floors
                .Include(f => f.Houses)  // Include the House
                .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
