namespace AuntyBCompere.Models.Data
{
    public class Booking
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public DateTime DateBooked { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Notes { get; set; }

        public Service Service { get; set; }
    }
}
