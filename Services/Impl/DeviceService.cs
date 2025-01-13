using DeviceManager.Context;
using DeviceManager.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeviceManager.Services.Impl;

public class DeviceService(ApplicationDbContext context) : IDeviceService
{
    public Task<IActionResult> CreateDevice(DeviceViewModel deviceViewModel)
    {
        try
        {
            var device = new Device
            {
                Name = deviceViewModel.Name,
                Code = deviceViewModel.Code,
                CategoryId = deviceViewModel.CategoryId,
                Status = deviceViewModel.Status,
            };
            context.Devices.Add(device);
            context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        return Task.FromResult<IActionResult>(new OkResult());
    }

    public async Task<IActionResult> DeleteDeviceById(int id)
    {
        var device = await context.Devices.FindAsync(id);
        if (device == null)
        {
            return new NotFoundResult();
        }

        context.Devices.Remove(device);
        context.SaveChanges();
        
        return await Task.FromResult<IActionResult>(new OkResult());
    }

    public async Task<IActionResult> UpdateDevice(DeviceViewModel deviceViewModel)
    {
        var deviceToUpdate =  await context.Devices.FindAsync(deviceViewModel.DeviceId);
        if (deviceToUpdate == null)
        {
            return new NotFoundResult();
        }
        
        deviceToUpdate.Name = deviceViewModel.Name;
        deviceToUpdate.Code = deviceViewModel.Code;
        deviceToUpdate.CategoryId = deviceViewModel.CategoryId;
        deviceToUpdate.Status = deviceViewModel.Status;
        
        context.Devices.Update(deviceToUpdate);
        context.SaveChanges();

        return new OkResult();
    }

    public async Task<Device> GetDeviceById(int id)
    {
        var device = await context.Devices.Include(d => d.Category).FirstAsync(d => d.DeviceId == id);
        if (device == null)
        {
            throw new Exception("Device not found");
        }

        return device;
    }

    public async Task<List<Device>> GetDevicesByCategoryId(int? categoryId)
    {
        if(categoryId == null)
        {
            return await context.Devices.Include(d => d.Category).ToListAsync();
        }
        return context.Devices.Where(d => d.CategoryId == categoryId).ToList();
    }

    public async Task<List<Device>> GetAllDevices()
    {
        var devices = await context.Devices.Include(d => d.Category).ToListAsync();
        return devices;
    }
}
