using KanbanBoard.Data.Entities;
using KanbanBoard.Repositories.Abstraction;
using KanbanBoard.Services.Abstraction;
using System.Threading.Tasks;

namespace KanbanBoard.Services.Implementation
{
    public class ItemService : IItemService
    {
        IRepository<JobItem> repository;

        public ItemService(IRepository<JobItem> repository)
        {
            this.repository = repository;
        }
        public async Task<JobItem> AddItem(JobItem item)
        {
            return await this.repository.Add(item);
        }

        public async Task DeleteJobItem(JobItem item)
        {
            await this.repository.Delete(await this.repository.Get(item.Id));
        }

        public async Task<JobItem> GetJobItem(int itemId)
        {
            return await this.repository.Get(itemId);
        }

        public async Task<JobItem> UpdateJobItem(JobItem item)
        {
            return await this.repository.Update(item);
        }
    }
}
