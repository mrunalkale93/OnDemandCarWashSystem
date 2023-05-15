using CarWashSystem.Models;

namespace CarWashSystem.Interface
{
    public interface IUser
    {
        Task<List<UserDetails>> GetUsers();
        Task<UserDetails> GetUserById(int id);
        Task<UserDetails> CreateUser(UserDetails user);
        Task<UserDetails> UpdateUser(int id, UserDetails user);
        Task<UserDetails> DeleteUser(int id);
    }
}
