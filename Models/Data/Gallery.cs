using System.ComponentModel.DataAnnotations;

namespace AuntyBCompere.Models.Data;

public class Gallery
{
    public int Id { get; set; }
    public int ServiceId { get; set; }
    [StringLength(50)]
    public string Name { get; set; }
    [StringLength(255)]
    public string Description { get; set; }
    [StringLength(255)]
    public string Url { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;

    //public Service Service { get; set; }
}