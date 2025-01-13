using System.ComponentModel.DataAnnotations;

namespace DeviceManager.Models;

public class UserViewModel
{
    public int UserId { get; set; }
    
    [Required]
    public string Fullname { get; set; } = null!;
    
    [Required]
    public string Email { get; set; } = null!;
    
    [Required]
    public string PhoneNumber { get; set; } = null!;
}
