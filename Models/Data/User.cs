using System.ComponentModel.DataAnnotations;

namespace AuntyBCompere.Models.Data;

public class User
{
    public int Id { get; set; }
    [StringLength(50)]
    public string FirstName { get; set; }
    [StringLength(50)]
    public string LastName { get; set; }
    [StringLength(50)]
    public string Username { get; set; }
    [StringLength(50)]
    public string Email { get; set; }
    [StringLength(255)]
    public string PasswordHash { get; set; }
    public DateTime DateCreated { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsSuperAdmin { get; set; }
}