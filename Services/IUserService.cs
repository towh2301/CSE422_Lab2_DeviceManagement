using DeviceManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManager.Services;

public interface IUserService
{
    Task<IActionResult> CreateUser(UserViewModel userViewModel);
    Task<User> GetUserById(int id);
    Task<List<User>> GetAllUsers();
    Task<IActionResult> UpdateUser(UserViewModel userViewModel);
    Task<IActionResult> DeleteUserById(int id);
}
