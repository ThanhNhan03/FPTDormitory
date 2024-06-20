using DormitoryFPT.Models.Domain;
using DormitoryFPT.Models.Dto;

namespace DormitoryFPT.Repository
{
    public interface IDormRepository
    {
        Task<List<DormDto>> GetAllAsync();
        Task<DormDto> GetByIdAsync(Guid id);

    }
}
