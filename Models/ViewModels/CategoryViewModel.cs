using System.ComponentModel.DataAnnotations;

namespace DeviceManager.Models;

public class CategoryViewModel
{
    public int CategoryId { get; set; }
    
    [Required] 
    public string Name { get; set; } = null!;
    
    [Required]
    public string? Description { get; set; } = null!;
}
