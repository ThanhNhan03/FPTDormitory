using DormitoryFPT.Models.Domain;

namespace DormitoryFPT.Repository
{
    public interface IFloorRepository
    {
        Task<IEnumerable<Floor>> GetAllFloors();
        Task<Floor> GetFloorById(Guid id);
    }
}
