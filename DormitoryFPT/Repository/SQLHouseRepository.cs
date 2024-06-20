using AutoMapper;
using DormitoryFPT.Data;
using DormitoryFPT.Models.Domain;
using DormitoryFPT.Models.Dto.HouseDataTransferObject;
using DormitoryFPT.Models.Dto.RoomDataTransferObject;
using Microsoft.EntityFrameworkCore;

namespace DormitoryFPT.Repository
{
    public class SQLHouseRepository : IHouseRepository
    {
        private readonly DormDbContext context;
        private readonly IMapper mapper;
        public SQLHouseRepository(DormDbContext context, IMapper mapper)
        {

            this.context = context;
            this.mapper = mapper;
        }
        //Create house
        public async Task<House> CreateAsync(House house)
        {
            await context.Houses.AddAsync(house);
            await context.SaveChangesAsync();
            return house;
        }
        //Delete house
        public async Task<House> DeleteAsync(Guid id)
        {
            var existingHouse = await context.Houses.FirstOrDefaultAsync(h => h.Id == id);
            if (existingHouse == null)
            {
                return null;
            }

            context.Houses.Remove(existingHouse);
            await context.SaveChangesAsync();

            return existingHouse;
        }

        public async Task<List<HouseDto>> GetAllAsync()
        {
            var houses = await context.Houses
                                      .Include(h => h.Floor)  // Include the Floor
                                      .Include(h => h.Rooms)  // Include the Rooms
                                      .ToListAsync();

            return mapper.Map<List<HouseDto>>(houses);
        }
        //Get house by id
        public async Task<House> GetByIdAsync(Guid id)
        {
            return await context.Houses
                                .Include(h => h.Floor)  // Include the Floor
                                .Include(h => h.Rooms)  // Include the Rooms
                                .FirstOrDefaultAsync(h => h.Id == id);
        }

        //Update house
        public async Task<House> UpdateAsync(Guid id, House house)
        {
            var existingHouse = await context.Houses.FirstOrDefaultAsync(h => h.Id == id);
            if (existingHouse == null)
            {
                return null;
            }

            existingHouse.Name = house.Name;
            existingHouse.Description = house.Description;
            existingHouse.Status = house.Status;
            existingHouse.FloorId = house.FloorId;

            context.Houses.Update(existingHouse);
            await context.SaveChangesAsync();

            return existingHouse;
        }


    }
}
