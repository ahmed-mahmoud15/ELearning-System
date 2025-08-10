using ELearning_System.Models;
using ELearning_System.Repositories;

namespace ELearning_System.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> userRepo;

        public UserService(IBaseRepository<User> userRepo)
        {
            this.userRepo = userRepo;
        }
        public async Task AddUserAsync(User user)
        {
            await userRepo.InsertAsync(user);
            await userRepo.SaveAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            await userRepo.DeleteAsync(id);
            await userRepo.SaveAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await userRepo.GetAllAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await userRepo.GetByIdAsync(id);
        }

        public async Task UpdateUserAsync(User user)
        {
            userRepo.Update(user);
            await userRepo.SaveAsync();
        }
    }
}
