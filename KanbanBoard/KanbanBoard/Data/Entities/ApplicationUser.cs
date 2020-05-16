using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace KanbanBoard.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public List<JobItem> JobItems { get; set; } = new List<JobItem>();
    }
}
