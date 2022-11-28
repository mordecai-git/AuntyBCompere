using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuntyBCompere.Models.Data;

public class Testimonial
{
    public int Id { get; set; }

    [StringLength(50)]
    [Required]
    public string Name { get; set; }

    [Required(ErrorMessage = "Your email is required.")]
    [DataType(DataType.EmailAddress, ErrorMessage = "Please provide a valid email address")]
    public string Email { get; set; }

    [StringLength(2000)]
    [Required(ErrorMessage = "Please give us your remarks.")]
    public string Content { get; set; }

    [StringLength(50)]
    public string Country { get; set; }

    [Range(1, 5, ErrorMessage = "Please rate Aunty 'B' Service")]
    public int Rating { get; set; }

    public DateTime DateCreated { get; set; }

    [NotMapped]
    public List<Service> Services { get; set; }
}