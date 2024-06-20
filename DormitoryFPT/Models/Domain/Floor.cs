namespace DormitoryFPT.Models.Domain
{
    public class Floor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public Guid DormId { get; set; }

        // Navigation properties
        public Dorm Dorm { get; set; }
        public ICollection<House> Houses { get; set; }
    }
}
