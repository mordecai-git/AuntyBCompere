using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuntyBCompere.Models.Data;

public class Service
{
    public int Id { get; set; }
    [StringLength(255)]
    public string Name { get; set; }
    [StringLength(255)]
    public string Tagline { get; set; }
    [StringLength(50)]
    public string ImageName { get; set; }
    [StringLength(50)]
    public string FaIcon { get; set; }
    [StringLength(5000)]
    public string Summary { get; set; }
    public string Content { get; set; }
    public bool IsStandard { get; set; }

    public ICollection<Gallery> Galleries { get; set; }
    public ICollection<BookingService> BookingServices { get; set; }


    [NotMapped]
    public bool IsSelected { get; set; } = false;
}