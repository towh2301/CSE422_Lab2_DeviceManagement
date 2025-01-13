using System.ComponentModel.DataAnnotations;

namespace DeviceManager.Models;

public class DeviceViewModel
{
    public int DeviceId { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Code is required")]
    public string Code { get; set; }

    [Required(ErrorMessage = "Category is required")]
    public int CategoryId { get; set; }

    public string CategoryName { get; set; }

    [Required(ErrorMessage = "Status is required")]
    public byte Status { get; set; }
}