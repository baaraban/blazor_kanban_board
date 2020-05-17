using System.Threading.Tasks;
using KanbanBoard.Data.Entities;
using Microsoft.AspNetCore.SignalR;

namespace KanbanBoard.Hubs
{
    public class BoardHub : Hub
    {
        public async Task ItemUpdate(int itemId)
        {
            await Clients.All.SendAsync("ItemUpdate", itemId);
        }

        public async Task ColumnUpdate(int columnId)
        {
            await Clients.All.SendAsync("ColumnUpdate", columnId);
        }

        public async Task ItemAdded(int columnId, int itemId)
        {
            await Clients.All.SendAsync("ItemAdded", columnId, itemId);
        }

        public async Task ItemDeleted(int columnId, int itemId)
        {
            await Clients.All.SendAsync("ItemDeleted", columnId, itemId);
        }
        public async Task ColumnAdded(int columnId)
        {
            await Clients.All.SendAsync("ColumnAdded", columnId);
        }

        public async Task ColumnDeleted(int columnId)
        {
            await Clients.All.SendAsync("ColumnDeleted", columnId);
        }
    }
}
