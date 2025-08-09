using ELearning_System.Models;

namespace ELearning_System.Services
{
    public interface IInstructorService
    {
        Task<IEnumerable<Instructor>> GetAllInstructorsAsync();
        Task<Instructor> GetInstructorByIdAsync(int id);
        Task AddInstructorAsync(Instructor record);
        Task UpdateInstructorAsync(Instructor record);
        Task DeleteInstructorAsync(int id);
    }
}
