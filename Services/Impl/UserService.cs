using DeviceManager.Context;
using DeviceManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeviceManager.Services.Impl;

public class UserService(ApplicationDbContext context) : IUserService
{
    public async Task<IActionResult> CreateUser(UserViewModel userViewModel)
    {
        var user = new User
        {
            Fullname = userViewModel.Fullname,
            Email = userViewModel.Email,
            PhoneNumber = userViewModel.PhoneNumber
        };
        
        context.Users.Add(user);
        context.SaveChangesAsync();

        return new OkResult();
    }

    public async Task<User> GetUserById(int id)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.UserId == id);
        if (user == null)
        {
            throw new  Exception("User not found");
        }
        return user;
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await context.Users.ToListAsync();
    }

    public async Task<IActionResult> UpdateUser(UserViewModel userViewModel)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.UserId == userViewModel.UserId);
        if (user == null)
        {
            return new NotFoundResult();
        }
        
        user.Fullname = userViewModel.Fullname;
        user.Email = userViewModel.Email;
        user.PhoneNumber = userViewModel.PhoneNumber;
        
        await context.SaveChangesAsync();
        
        return new OkResult();
    }

    public async Task<IActionResult> DeleteUserById(int id)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.UserId == id);
        if (user == null)
        {
            return new NotFoundResult();
        }
        
        context.Users.Remove(user);
        await context.SaveChangesAsync();
        
        return new OkResult();
    }
}
