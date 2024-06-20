namespace DormitoryFPT.Models.Dto
{
    public class DormDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Nested DTOs for related entities
        public List<FloorDto> Floors { get; set; }
    }
}
