namespace client_app.Models
{
    public class Room
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public Guid HouseId { get; set; }

        // Navigation property
        //public House House { get; set; }
    }
}
