using CarWashSystem.Data;
using CarWashSystem.Interface;
using CarWashSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CarWashSystem.Repository
{
    public class AddonRepository : IAddon
    {
        private readonly CarWashDbContext _context;

        public AddonRepository(CarWashDbContext context) 
        {
            this._context = context;
        }
        public async Task<AddOn> CreateAddOn(AddOn addon)
        {
           await _context.AddOns.AddAsync(addon);
            await _context.SaveChangesAsync();
            return addon;
        }

        public async Task<AddOn> DeleteAddOn(int id)
        {
            var addon = await _context.AddOns.FirstOrDefaultAsync(x => x.Id == id);
            if (addon == null)
            {
                return null;
            }
            _context.AddOns.Remove(addon);
            await _context.SaveChangesAsync();
            return addon;
        }

        public async Task<List<AddOn>> GetAddOn()
        {
            return await _context.AddOns.ToListAsync();
        }

        public async Task<AddOn> GetAddOnById(int id)
        {
             return await _context.AddOns.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<AddOn> UpdateAddOn(int id, AddOn addon)
        {
            var existingdata = await _context.AddOns.FirstOrDefaultAsync(x => x.Id == id);
            if (addon == null)
            {
                return null;
            }

            existingdata.Name = addon.Name;
            existingdata.Description = addon.Description;
            existingdata.Price = addon.Price;

            await _context.SaveChangesAsync();
            return existingdata;
        }
    }
}
