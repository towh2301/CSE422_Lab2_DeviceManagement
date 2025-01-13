using DeviceManager.Context;
using DeviceManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeviceManager.Services.Impl;

public class CategoryService(ApplicationDbContext context)  : ICategoryService
{
    public async Task<IActionResult> CreateCategory(CategoryViewModel categoryViewModel)
    {
        var category = new Category
        {
            Name = categoryViewModel.Name,
            Description = categoryViewModel.Description
        };
        
        await context.Categories.AddAsync(category);
        await context.SaveChangesAsync();
        
        return new OkResult();
    }

    public async Task<IActionResult> DeleteCategoryById(int id)
    {
        var category = await context.Categories.FindAsync(id);
        if (category == null)
        {
            return new NotFoundResult();
        }
        
        context.Categories.Remove(category);
        await context.SaveChangesAsync();
        
        return await Task.FromResult<IActionResult>(new OkResult());
    }

    public async Task<IActionResult> UpdateCategory(CategoryViewModel categoryViewModel)
    {
        var category = await context.Categories.FindAsync(categoryViewModel.CategoryId);
        if (category == null)
        {
            return new NotFoundResult();
        }
        
        category.Name = categoryViewModel.Name;
        category.Description = categoryViewModel.Description;
        
        await context.SaveChangesAsync();
        
        return new OkResult();
    }

    public async Task<Category> GetCategoryById(int id)
    {
        var category = await context.Categories.FindAsync(id);
        if (category == null)
        {
            throw new Exception("Category not found");
        }
        
        return category;
    }

    public async Task<List<Category>> GetAllCategories()
    {
        return await context.Categories.ToListAsync();
    }
}
