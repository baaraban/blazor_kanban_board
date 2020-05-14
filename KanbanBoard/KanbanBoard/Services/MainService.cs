using KanbanBoard.Data.Entities;
using KanbanBoard.Repositories.Abstraction;
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


        public async Task<List<ApplicationUser>> GetAllUsers() {
            var users = await userRepo.GetAll();
            return users.ToList();
        }

        public async Task<List<JobColumn>> GetColumns()
        {
            var columns = await columnsRepo.GetAll();
            return columns.ToList();
        }

        public async Task<JobColumn> AddColumn(JobColumn column)
        {
            return await this.columnsRepo.Add(column);
        }

    }
}
