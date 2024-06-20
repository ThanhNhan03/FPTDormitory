namespace DormitoryFPT.Models.Domain
{
    public class Dorm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation property
        public ICollection<Floor> Floors { get; set; }
    }
}
