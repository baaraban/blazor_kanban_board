using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KanbanBoard.Data.DTO;
using KanbanBoard.Data.Entities;
using KanbanBoard.Repositories.Abstraction;
using KanbanBoard.Services.Abstraction;

namespace KanbanBoard.Services.Implementation
{
    public class UserService : IUserService
    {
        IRepository<ApplicationUser> repository;

        public UserService(IRepository<ApplicationUser> userRepository)
        {
            this.repository = userRepository;
        }
        public async Task<List<ViewUser>> GetAllUsers()
        {
            var users = await repository.GetAll();
            return users
                .Select(x => new ViewUser { UserId = x.Id, UserEmail = x.Email })
                .ToList();
        }
    }
}
