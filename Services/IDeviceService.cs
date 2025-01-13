using DeviceManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManager.Services;

public interface IDeviceService
{
    Task<IActionResult> CreateDevice(DeviceViewModel deviceViewModel);
    Task<IActionResult> DeleteDeviceById(int id);
    Task<IActionResult> UpdateDevice(DeviceViewModel deviceViewModel);
    Task<Device> GetDeviceById(int id);
    
    Task<List<Device>> GetDevicesByCategoryId(int? categoryId);
    Task<List<Device>> GetAllDevices();
}
