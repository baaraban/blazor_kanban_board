using KanbanBoard.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KanbanBoard.Services.Abstraction
{
    interface IColumnService
    {
        Task<List<JobColumn>> GetColumns();
        Task<JobColumn> AddColumn(JobColumn column);
        Task<JobColumn> UpdateJobColumn(JobColumn item);
        Task DeleteJobColumn(JobColumn item);
    }
}
