using KanbanBoard.Data.DTO;
using KanbanBoard.Data.Entities;
using KanbanBoard.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoard.Services
{
    public class MainService
    {
        IRepository<ApplicationUser> userRepo;
        IRepository<JobColumn> columnsRepo;
        IRepository<JobItem> itemsRepo;

        public MainService(IRepository<ApplicationUser> userRepository,
            IRepository<JobColumn> columnsRepository,
            IRepository<JobItem> jobRepository)
        {                           
            userRepo = userRepository;
            columnsRepo = columnsRepository;
            itemsRepo = jobRepository;
        }


        public async Task<List<ViewUser>> GetAllUsers() {
            var users = await userRepo.GetAll();
            return users
                .Select(x => new ViewUser { UserId = x.Id, UserEmail = x.Email})
                .ToList();
        }

        public async Task<List<JobColumn>> GetColumns()
        {
            var columns = await columnsRepo
                .AsQueryable()
                .Include(x => x.JobItems)
                .ToListAsync();
            return columns.ToList();
        }

        public async Task<JobColumn> AddColumn(JobColumn column)
        {
            return await this.columnsRepo.Add(column);
        }

        public async Task<JobItem> AddItem(JobItem item)
        {
            return await this.itemsRepo.Add(item);
        }

        public async Task<JobItem> UpdateJobItem(JobItem item)
        {
            return await this.itemsRepo.Update(item);
        }

        public async Task<JobColumn> UpdateJobColumn(JobColumn item)
        {
            return await this.columnsRepo.Update(item);
        }

        public async Task DeleteJobItem(JobItem item)
        {
            await this.itemsRepo.Delete(item);
        }

        public async Task DeleteJobColumn(JobColumn item)
        {
            await this.columnsRepo.Delete(item);
        }

        public async Task<JobItem> GetJobItem(int itemId)
        {
            return await this.itemsRepo.Get(itemId);
        }
    }
}
