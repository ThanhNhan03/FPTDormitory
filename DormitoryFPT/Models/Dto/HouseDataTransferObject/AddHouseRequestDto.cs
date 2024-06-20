namespace DormitoryFPT.Models.Dto.HouseDataTransferObject
{
    public class AddHouseRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public Guid FloorId { get; set; }
    }
}
