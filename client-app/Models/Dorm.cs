namespace client_app.Models
{
    public class Dorm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Floor> Floors { get; set; }
    }
}
