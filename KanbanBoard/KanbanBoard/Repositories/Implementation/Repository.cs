using KanbanBoard.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoard.Repositories.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext context;
        private readonly DbSet<TEntity> table;

        public Repository(DbContext context)
        {
            this.context = context;
            this.table = this.context.Set<TEntity>();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            await this.table.AddAsync(entity);
            await this.context.SaveChangesAsync();
            return entity;
        }

        public IQueryable<TEntity> AsQueryable() =>  this.table.AsQueryable<TEntity>();

        public async Task Delete(TEntity entity)
        {
            this.table.Remove(entity);
            await this.context.SaveChangesAsync();
        }

        public async Task<TEntity> Get(object id) => await this.table.FindAsync(id);

        public async Task<IEnumerable<TEntity>> GetAll() => await this.table.ToListAsync();

        public async Task<TEntity> Update(TEntity entity)
        {
            this.table.Attach(entity);
            this.context.Entry(entity).State = EntityState.Modified;
            await this.context.SaveChangesAsync();
            return entity;
        }
    }
}
