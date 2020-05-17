using KanbanBoard.Data.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KanbanBoard.Services.Abstraction
{
    interface IUserService
    {
        Task<List<ViewUser>> GetAllUsers();
    }
}
