using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeviceManager.Models;

public class Device
{
    [Key]
    public int DeviceId { get; set; }

    [Required] public string Name { get; set; } = null!;

    [Required] public string Code { get; set; } = null!;
    
    [Required]
    public int CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    public Category Category { get; set; } = null!;

    // public int UserId { get; set; }
    // [ForeignKey("userId")]
    // public User User { get; set; } = null!;

    [Required]
    public byte Status { get; set; }
    
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedAt { get; set; }
    
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }
}
