using KanbanBoard.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KanbanBoard.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<JobColumn> Columns{ get; set;}
        public virtual DbSet<JobItem> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobItem>().HasKey(x => x.Id);
            modelBuilder.Entity<JobItem>().HasOne(x => x.User).WithMany(x => x.JobItems).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<JobItem>().HasOne(x => x.JobColumn).WithMany(x => x.JobItems).HasForeignKey(x => x.JobColumnId).OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<JobColumn>().HasKey(x => x.Id);


            base.OnModelCreating(modelBuilder);
        }
    }
}
