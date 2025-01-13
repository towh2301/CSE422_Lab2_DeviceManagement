using DeviceManager.Models;
using DeviceManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManager.Controllers;

public class CategoryController(ICategoryService categoryService) : Controller
{
    public async Task<IActionResult> Index()
    {
        ViewBag.categories = await categoryService.GetAllCategories();
        return View(ViewBag.categories);
    }
    
    public async Task<IActionResult> Create()
    {
        return View("~/Views/Category/CreateCategory.cshtml");
    }
    
    // Add a new device
    public async Task<IActionResult> CreateCategory(CategoryViewModel categoryViewModel)
    {
        if(await categoryService.CreateCategory(categoryViewModel) is not OkResult)
        {
            return BadRequest();
        }
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Update(int id)
    {
        var category = await categoryService.GetCategoryById(id);
        return View("~/Views/Category/UpdateCategory.cshtml", category);
    }
    
    // Update a device
    public async Task<IActionResult> UpdateCategory(CategoryViewModel categoryViewModel)
    {
        await categoryService.UpdateCategory(categoryViewModel);
        return RedirectToAction("Index");
    }
    
    // Delete a device
    public async Task<IActionResult> DeleteCategory(int id)
    {
        if(await categoryService.DeleteCategoryById(id) is not OkResult)
        {
            return BadRequest();
        }
        return RedirectToAction("Index");
    }
}
