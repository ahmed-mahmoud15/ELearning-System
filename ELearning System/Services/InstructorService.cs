using ELearning_System.Models;
using ELearning_System.Repositories;

namespace ELearning_System.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly IBaseRepository<Instructor> instructorRepo;

        public InstructorService(IBaseRepository<Instructor> repo)
        {
            instructorRepo = repo;
        }

        public async Task AddInstructorAsync(Instructor record)
        {
            await instructorRepo.InsertAsync(record);
            await instructorRepo.SaveAsync();
        }

        public async Task DeleteInstructorAsync(int id)
        {
            await instructorRepo.DeleteAsync(id);
            await instructorRepo.SaveAsync();
        }

        public async Task<IEnumerable<Instructor>> GetAllInstructorsAsync()
        {
            return await instructorRepo.GetAllAsync();
        }

        public async Task<Instructor> GetInstructorByIdAsync(int id)
        {
            return await instructorRepo.GetByIdAsync(id);
        }

        public async Task UpdateInstructorAsync(Instructor record)
        {
            instructorRepo.Update(record);
            await instructorRepo.SaveAsync();
        }
    }
}
