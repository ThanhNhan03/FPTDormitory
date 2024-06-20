using DormitoryFPT.Models.Dto.HouseDataTransferObject;

namespace DormitoryFPT.Models.Dto
{
    public class FloorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public Guid DormId { get; set; }

        //// Dorm DTO
        //public DormDto Dorm { get; set; }

        // Nested DTOs for related entities
        public ICollection<HouseDto> Houses { get; set; }
    }
}
