using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RunBuddyBackend.DataAccess;
using RunBuddyBackend.Models;

namespace RunBuddyBackend.BusinessLogic
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Create a new user
        public async Task<User> CreateUserAsync(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            return await _userRepository.AddUserAsync(user);
        }

        // Get a user by ID
        public async Task<User?> GetUserByIdAsync(int id)
        {
            if (id <= 0) throw new ArgumentException("Invalid user ID", nameof(id));

            return await _userRepository.GetUserByIdAsync(id);
        }

        // Get all users
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        // Update user information
        public async Task<User> UpdateUserAsync(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (user.Id <= 0) throw new ArgumentException("Invalid user ID", nameof(user.Id));

            return await _userRepository.UpdateUserAsync(user);
        }

        // Delete a user by ID
        public async Task<bool> DeleteUserAsync(int id)
        {
            if (id <= 0) throw new ArgumentException("Invalid user ID", nameof(id));

            return await _userRepository.DeleteUserAsync(id);
        }
    }
}
