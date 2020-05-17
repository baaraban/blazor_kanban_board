using KanbanBoard.Data.Entities;
using System.Threading.Tasks;

namespace KanbanBoard.Services.Abstraction
{
    interface IItemService
    {
        Task<JobItem> AddItem(JobItem item);
        Task<JobItem> UpdateJobItem(JobItem item);
        Task DeleteJobItem(JobItem item);
        Task<JobItem> GetJobItem(int itemId);
    }
}
