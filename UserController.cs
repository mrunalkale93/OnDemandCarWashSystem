using CarWashSystem.Data;
using CarWashSystem.DTO;
using CarWashSystem.Interface;
using CarWashSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarWashSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly CarWashDbContext _context;
        private readonly IUser userrepository;

        public UserController(CarWashDbContext context,IUser userrepository)
        {
            _context = context;
            this.userrepository = userrepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDetails>>> GetUser()
        {
            var users= await userrepository.GetUsers();
            if (_context.Users == null)
            {
                return NotFound();
            }
            var userdto = new List<Userdto>();
            foreach (var user in users)
            {
                
                userdto.Add(new Userdto()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.EmailAddress,
                    Password = user.Password,
                    Address= user.CompleteAddress,
                    Role=user.Role
                });
            }

            return Ok(userdto); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<UserDetails>>> GetUserById(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }

            var user= await userrepository.GetUserById(id);
            if(user == null)
            {
                return NotFound();
            }
            var userdto = new Userdto()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.EmailAddress,
                Password = user.Password,
                Address = user.CompleteAddress,
                Role = user.Role
            };

            return Ok(userdto);
        }

        
        [HttpPost]
        public async Task<ActionResult<IEnumerable<UserDetails>>> PostUser(CreateUserdto createuser)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = new UserDetails() {
                Name = createuser.Name,
                EmailAddress = createuser.EmailAddress,
                Password = createuser.Password,
                CompleteAddress = createuser.Address,
                Role = createuser.Role
        };
            user = await userrepository.CreateUser(user);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id,UserUpdatedto userUpdatedto)
        {
            var user = new UserDetails()
            {
                Name = userUpdatedto.Name,
                EmailAddress = userUpdatedto.Email,
                Password = userUpdatedto.Password,
                CompleteAddress = userUpdatedto.Address,
            };
            if(_context.Users == null)
            {
                return NotFound();
            }
            user = await userrepository.UpdateUser(id,user);
            
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                user.Name = userUpdatedto.Name;
                user.Name = userUpdatedto.Name;
                user.Password = userUpdatedto.Password;
                user.Name = userUpdatedto.Name;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteUser(int id)
        {
            if(_context.Users == null)
            {
                return NotFound();
            }
            var user = await userrepository.DeleteUser(id);
            if (user == null)
            {
                return NotFound();
            }
            // no asyn method for remove so no await for remove

            return Ok(user);
        }
    }
}
