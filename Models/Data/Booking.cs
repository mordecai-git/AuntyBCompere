using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuntyBCompere.Models.Data
{
    public class Booking
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Please select a service.")]
        //public int ServiceId { get; set; }

        [Required(ErrorMessage = "Please select a date and time to book an appointment for.")]
        public DateTime DateBooked { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Please provied a name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Your email is required.")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Please use a valid email address")]
        public string Email { get; set; }

        public string Phone { get; set; }
        public string Notes { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public bool Test {get;set;}

        public ICollection<BookingService> BookingServices { get; set; }

        [NotMapped]
        public List<Service> Services { get; set; }
    }
}
