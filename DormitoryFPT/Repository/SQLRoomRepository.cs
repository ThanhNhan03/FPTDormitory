using DormitoryFPT.Data;
using DormitoryFPT.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DormitoryFPT.Repository
{
    public class SQLRoomRepository : IRoomRepository
    {
        private readonly DormDbContext context;
        public SQLRoomRepository(DormDbContext context)
        {
            this.context = context;
        }
        //Create room
        public async Task<Room> CreateAsync(Room room)
        {
            // Check if HouseId exists in the database
            var houseExists = await context.Houses.AnyAsync(h => h.Id == room.HouseId);
            if (!houseExists)
            {
                throw new Exception("HouseId does not exist");
            }

            await context.Rooms.AddAsync(room);
            await context.SaveChangesAsync();
            return room;
        }
        //Delete room
        public async Task<Room> DeleteAsync(Guid id)
        {
            var existingRegion = await context.Rooms.FirstOrDefaultAsync(x => x.Id == id);

            if (existingRegion == null)
            {
                return null;
            }

            context.Rooms.Remove(existingRegion);
            await context.SaveChangesAsync();
            return existingRegion;
        }

        //Get all rooms
        public async Task<List<Room>> GetAllAsync()
        {
            return await context.Rooms.Include("House").ToListAsync();
        }
        //Get room by id
        public async Task<Room> GetByIdAsync(Guid id)
        {
            return await context.Rooms.Include("House").FirstOrDefaultAsync(x => x.Id == id);
        }

        //Update room
        public async Task<Room> UpdateAsync(Guid id, Room room)
        {
            // Check if the room exists in the database
            var existingRoom = await context.Rooms.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRoom == null)
            {
                throw new Exception("Room not found");
            }

            // Check if HouseId exists in the database
            var houseExists = await context.Houses.AnyAsync(h => h.Id == room.HouseId);
            if (!houseExists)
            {
                throw new Exception("HouseId does not exist");
            }

            // Update the room properties
            existingRoom.Status = room.Status;
            existingRoom.Description = room.Description;
            existingRoom.Type = room.Type;
            existingRoom.Price = room.Price;
            existingRoom.HouseId = room.HouseId;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Log the exception (consider using a logging framework)
                // e.g., _logger.LogError(ex, "An error occurred while updating the room.");
                throw new Exception("An error occurred while updating the room. Please try again.", ex);
            }

            return existingRoom;
        }
    }
}
    