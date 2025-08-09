
using ELearning_System.Data;
using Microsoft.EntityFrameworkCore;

namespace ELearning_System.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<T> table;
        public BaseRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.table = context.Set<T>();
        }

        public async Task DeleteAsync(object id)
        {
            T? entity = await table.FindAsync(id);
            if (entity != null) {
                table.Remove(entity);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await table.FindAsync(id);
        }

        public async Task InsertAsync(T record)
        {
            await table.AddAsync(record);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T record)
        {
            table.Attach(record);
            context.Entry(record).State = EntityState.Modified;
        }
    }
}
