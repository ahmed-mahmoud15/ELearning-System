using ELearning_System.Models;
using ELearning_System.Repositories;

namespace ELearning_System.Services
{
    public class StudentService : IStudentService
    {
        private readonly IBaseRepository<Student> studentRepository;
        public StudentService(IBaseRepository<Student> repo) {
            this.studentRepository = repo;
        }
        public async Task AddStudentAsync(Student student)
        {
            await studentRepository.InsertAsync(student);
            await studentRepository.SaveAsync();
        }

        public async Task DeleteStudentAsync(int id)
        {
            await this.studentRepository.DeleteAsync(id);
            await this.studentRepository.SaveAsync();
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await studentRepository.GetAllAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await studentRepository.GetByIdAsync(id);
        }

        public async Task UpdateStudentAsync(Student student)
        {
            await studentRepository.UpdateAsync(student);
            await studentRepository.SaveAsync();
        }
    }
}
