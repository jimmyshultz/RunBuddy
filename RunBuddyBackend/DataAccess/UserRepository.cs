using RunBuddyBackend.DataAccess;
using RunBuddyBackend.Models;
using RunBuddyBackend.Data;
using Microsoft.EntityFrameworkCore;

namespace RunBuddyBackend.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly RunBuddyContext _context;

        public UserRepository(RunBuddyContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> AddUserAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
        
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return user; // Return the added user
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
        
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user; // Return the updated user
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await GetUserByIdAsync(id);
            if (user == null)
                return false;
        
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true; // Return true if the user was successfully deleted
        }
    }
}
