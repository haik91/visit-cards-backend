using Microsoft.EntityFrameworkCore;
using VisitCardDemo.Entities;

namespace VisitCardDemo.DbContexts
{
    public class VisitCardContext : DbContext
    {
        public VisitCardContext(DbContextOptions<VisitCardContext> options)
            : base(options)
        {
        }

        public DbSet<VisitCard> VisitCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}