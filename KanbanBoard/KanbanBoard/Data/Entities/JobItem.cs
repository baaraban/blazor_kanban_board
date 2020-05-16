namespace KanbanBoard.Data.Entities
{
    public class JobItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Place { get; set; }

        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        public JobColumn JobColumn { get; set; }
        public int? JobColumnId { get; set; }
    }
}
