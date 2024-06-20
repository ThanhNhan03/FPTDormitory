using AutoMapper;
using DormitoryFPT.Data;
using DormitoryFPT.Models.Domain;
using DormitoryFPT.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace DormitoryFPT.Repository
{
    public class SQLDormRepository : IDormRepository
    {
        private readonly DormDbContext context;
        private readonly IMapper mapper;

        public SQLDormRepository(DormDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<DormDto>> GetAllAsync()
        {
            var dorms = await context.Dorms
                .Include(d => d.Floors)  // Include the Floors
                .ToListAsync();

            return mapper.Map<List<DormDto>>(dorms);
        }

        public async Task<DormDto> GetByIdAsync(Guid id)
        {
            var dorm = await context.Dorms
                .Include(d => d.Floors)  // Include the Floors
                .FirstOrDefaultAsync(d => d.Id == id);

            return mapper.Map<DormDto>(dorm);
        }
    }
}
