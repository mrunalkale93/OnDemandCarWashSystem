using CarWashSystem.Models;

namespace CarWashSystem.Interface
{
    public interface IWashPackage
    {
        Task<List<WashPackageDetails>> GetAllWashPackage();
        Task<WashPackageDetails> GetWashPackageById(int id);
        Task<WashPackageDetails> CreateWashPackage(WashPackageDetails washPackage);
        Task<WashPackageDetails> UpdateWashPackage(int id, WashPackageDetails washPackage);
        Task<WashPackageDetails> DeleteWashPackage(int id);
    }
}
