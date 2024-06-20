namespace DormitoryFPT.Models.Dto.RoomDataTransferObject
{
    public class AddRoomRequestDto
    {
        public string Status { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public Guid HouseId { get; set; }
    }
}
