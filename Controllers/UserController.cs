using DeviceManager.Models;
using DeviceManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManager.Controllers;

public class UserController(IUserService userService) : Controller
{
    // GET
    public async Task<IActionResult> Index()
    {
        ViewBag.users = await userService.GetAllUsers();
        return View(ViewBag.users);
    }
    
    public async Task<IActionResult> Create()
    {
        return View("~/Views/User/CreateUser.cshtml");
    }
    
    // Add a new device
    public async Task<IActionResult> CreateUser(UserViewModel userViewModel)
    {
        if(await userService.CreateUser(userViewModel) is not OkResult)
        {
            return BadRequest();
        }
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Update(int id)
    {
        var user = await userService.GetUserById(id);
        return View("~/Views/User/UpdateUser.cshtml", user);
    }
    
    // Update a device
    public async Task<IActionResult> UpdateUser(UserViewModel userViewModel)
    {
        await userService.UpdateUser(userViewModel);
        return RedirectToAction("Index");
    }
    
    // Delete a device
    public async Task<IActionResult> DeleteUser(int id)
    {
        if(await userService.DeleteUserById(id) is not OkResult)
        {
            return BadRequest();
        }
        return RedirectToAction("Index");
    }
}
