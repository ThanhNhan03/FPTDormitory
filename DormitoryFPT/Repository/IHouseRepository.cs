using DormitoryFPT.Models.Domain;
using DormitoryFPT.Models.Dto.HouseDataTransferObject;

namespace DormitoryFPT.Repository
{
    public interface IHouseRepository
    {
        Task<List<HouseDto>> GetAllAsync();
        Task<House> GetByIdAsync(Guid id);
        Task<House> CreateAsync(House house);
        Task<House> UpdateAsync(Guid id, House house);  
        Task<House> DeleteAsync(Guid id);
    }
}
