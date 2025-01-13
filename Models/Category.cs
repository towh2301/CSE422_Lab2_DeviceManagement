using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeviceManager.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }

    [Required] public string Name { get; set; } = null!;
    
    [Required]
    public string? Description { get; set; } = null!;
    
    public ICollection<Device> Devices { get; set; } = new List<Device>();
    
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedAt { get; set; }
    
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }
}
