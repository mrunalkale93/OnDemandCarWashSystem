using CarWashSystem.Data;
using CarWashSystem.Interface;
using CarWashSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CarWashSystem.Repository
{
    public class UserRepository : IUser
    {
        private readonly CarWashDbContext context;

        public UserRepository(CarWashDbContext context)
        {
            this.context = context;
        }

        public async Task<UserDetails> CreateUser(UserDetails user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }



        public async Task<List<UserDetails>> GetUsers()
        {
            return await context.Users.ToListAsync();
        }
        public async Task<UserDetails> GetUserById(int id)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<UserDetails> UpdateUser(int id, UserDetails user)
        {
            var existingdata = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return null;
            }

            existingdata.Name = user.Name;
            existingdata.EmailAddress = user.EmailAddress;
            existingdata.Password = user.Password;
            existingdata.CompleteAddress = user.Password;

            await context.SaveChangesAsync();
            return existingdata;
        }
        public async Task<UserDetails> DeleteUser(int id)
        {
            var user=await context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return null;
            }
            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return user;
        }
    }
}
