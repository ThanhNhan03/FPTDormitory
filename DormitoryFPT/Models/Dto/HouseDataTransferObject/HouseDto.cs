using DormitoryFPT.Models.Domain;
using DormitoryFPT.Models.Dto.RoomDataTransferObject;

namespace DormitoryFPT.Models.Dto.HouseDataTransferObject
{
    public class HouseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string FloorName { get; set; }

        //// Floor DTO
        //public FloorDto Floor { get; set; }

        // Nested DTOs for related entities
        public List<RoomDto> Rooms { get; set; }
    }
}
