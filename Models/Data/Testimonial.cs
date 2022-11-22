using System.ComponentModel.DataAnnotations;

namespace AuntyBCompere.Models.Data;

public class Testimonial
{
    public int Id { get; set; }
    public int ServiceId { get; set; }
    [StringLength(50)]
    public string Name { get; set; }
    [StringLength(255)]
    public string Position { get; set; }
    [StringLength(2000)]
    public string Content { get; set; }
    public DateTime DateCreated { get; set; }

    public  Service Service { get; set; }
}