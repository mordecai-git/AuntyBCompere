namespace AuntyBCompere.Models.ViewModels
{
    public class TestimonialView
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Content { get; set; }

        public string Country { get; set; }

        public int Rating { get; set; }

        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }

        public List<string> Services { get; set; }
    }
}
