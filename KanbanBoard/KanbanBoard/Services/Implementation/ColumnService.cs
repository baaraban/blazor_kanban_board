using KanbanBoard.Data.Entities;
using KanbanBoard.Repositories.Abstraction;
using KanbanBoard.Services.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoard.Services.Implementation
{
    public class ColumnService : IColumnService
    {
        IRepository<JobColumn> repository;
       
        public ColumnService(IRepository<JobColumn> repository)
        {                           
            this.repository = repository;
        }

        public async Task<List<JobColumn>> GetColumns()
        {
            var columns = await repository
                .AsQueryable()
                .Include(x => x.JobItems)
                .ToListAsync();
            return columns.ToList();
        }

        public async Task<JobColumn> AddColumn(JobColumn column)
        {
            return await this.repository.Add(column);
        }

        public async Task<JobColumn> UpdateJobColumn(JobColumn item)
        {
            return await this.repository.Update(item);
        }

        public async Task DeleteJobColumn(JobColumn item)
        {
            await this.repository.Delete(item);
        }
    }
}
