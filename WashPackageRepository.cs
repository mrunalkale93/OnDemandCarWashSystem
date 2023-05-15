using CarWashSystem.Data;
using CarWashSystem.Interface;
using CarWashSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CarWashSystem.Repository
{
    public class WashPackageRepository : IWashPackage
    {
        private readonly CarWashDbContext context;

        public WashPackageRepository(CarWashDbContext context) 
        {
            this.context = context;
        }
        public async Task<WashPackageDetails> DeleteWashPackage(int id)
        {
            var washPackage = await context.WashPackages.FirstOrDefaultAsync(x => x.PackageId == id);
            if (washPackage == null)
            {
                return null;
            }
            context.WashPackages.Remove(washPackage);
            await context.SaveChangesAsync();
            return washPackage;
        }

        public async Task<List<WashPackageDetails>> GetWashPackage()
        {
            return await context.WashPackages.ToListAsync();
        }

        public async Task<WashPackageDetails> GetWashPackageById(int id)
        {
            return await context.WashPackages.FirstOrDefaultAsync(x => x.PackageId == id);
        }

        public async Task<WashPackageDetails> UpdateWashPackage(int id, WashPackageDetails washPackage)
        {
            var existingdata = await context.WashPackages.FirstOrDefaultAsync(x => x.PackageId == id);
            if (washPackage == null)
            {
                return null;
            }

            existingdata.Name = washPackage.Name;
            existingdata.Description = washPackage.Description;
            existingdata.Price = washPackage.Price;

            await context.SaveChangesAsync();
            return existingdata;
        }

        public async Task<WashPackageDetails> CreateWashPackage(WashPackageDetails washPackage)
        {
            await context.WashPackages.AddAsync(washPackage);
            await context.SaveChangesAsync();
            return washPackage;
        }

        public Task<List<WashPackageDetails>> GetAllWashPackage()
        {
            throw new NotImplementedException();
        }
    }
}
