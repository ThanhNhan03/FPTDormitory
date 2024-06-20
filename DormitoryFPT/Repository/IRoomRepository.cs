using DormitoryFPT.Models.Domain;

namespace DormitoryFPT.Repository
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetAllAsync();
        Task<Room> GetByIdAsync(Guid id);
        Task<Room> CreateAsync(Room region);
        Task<Room> UpdateAsync(Guid id, Room room);
        Task<Room> DeleteAsync(Guid id);
    }
}
