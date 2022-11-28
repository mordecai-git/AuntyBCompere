namespace AuntyBCompere.Models.Data
{
    public class TestimonialService
    {
        public int TestimonialId { get; set; }
        public int ServiceId { get; set; }

        public Testimonial Testimonial { get; set; }
        public Service Service { get; set; }
    }
}