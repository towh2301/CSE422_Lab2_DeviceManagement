using DeviceManager.Models;
using DeviceManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManager.Controllers;

public class DeviceController(IDeviceService deviceService, ICategoryService categoryService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(int? categoryId)
    {
        ViewBag.currentCategoryId = "all";
        ViewBag.categories = await categoryService.GetAllCategories();
        ViewBag.devices = await deviceService.GetDevicesByCategoryId(categoryId);
        ViewBag.currentCategoryId = categoryId == null ? "all" : categoryId.ToString();
        return View(ViewBag.categories);
    }
    
    
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.categories = await categoryService.GetAllCategories();
        return View("~/Views/Device/CreateDevice.cshtml");
    }
    
    // Add a new device
    public async Task<IActionResult> CreateDevice(DeviceViewModel deviceViewModel)
    {
        if(await deviceService.CreateDevice(deviceViewModel) is not OkResult)
        {
            return BadRequest();
        }
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        ViewBag.categories = await categoryService.GetAllCategories();
        var device = await deviceService.GetDeviceById(id);
        return View("~/Views/Device/UpdateDevice.cshtml", device);
    }
    
    // Update a device
    public async Task<IActionResult> UpdateDevice(DeviceViewModel deviceViewModel)
    {
        await deviceService.UpdateDevice(deviceViewModel);
        return RedirectToAction("Index");
    }
    
    // Delete a device
    public async Task<IActionResult> DeleteDevice(int id)
    {
        if(await deviceService.DeleteDeviceById(id) is not OkResult)
        {
            return BadRequest();
        }
        return RedirectToAction("Index");
    }
}
