using DeviceManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManager.Services;

public interface ICategoryService
{
    Task<IActionResult> CreateCategory(CategoryViewModel category);
    Task<IActionResult> DeleteCategoryById(int id);
    Task<IActionResult> UpdateCategory(CategoryViewModel category);
    Task<Category> GetCategoryById(int id);
    Task<List<Category>> GetAllCategories();
}
