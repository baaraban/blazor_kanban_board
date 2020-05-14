using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoard.Data.Entities
{
    public class JobColumn
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Place { get; set; }

        public List<JobItem> JobItems { get; set; }
    }
}
