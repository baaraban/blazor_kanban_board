using KanbanBoard.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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

        public TEntity Add(TEntity entity)
        {
            this.table.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public IQueryable<TEntity> AsQueryable() => this.table.AsQueryable<TEntity>();

        public void Delete(TEntity entity)
        {
            this.table.Remove(entity);
            this.context.SaveChanges();
        }

        public TEntity Get(object id) => this.table.Find(id);

        public IEnumerable<TEntity> GetAll() => this.table.ToList();

        public TEntity Update(TEntity entity)
        {
            this.table.Attach(entity);
            this.context.Entry(entity).State = EntityState.Modified;
            this.context.SaveChanges();
            return entity;
        }
    }
}
