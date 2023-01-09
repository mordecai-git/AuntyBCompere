namespace AuntyBCompere.Models.ViewModels
{
    public class BookingView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Notes { get; set; }
        public DateTime DateBooked { get; set; }
        public DateTime DateCreated { get; set; }
        public List<string> ServicesBooked { get; set; }
        public bool Expired { get { return DateTime.Now < DateBooked; } }
    }
}
