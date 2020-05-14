using System.Collections.Generic;

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
