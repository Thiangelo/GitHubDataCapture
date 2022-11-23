using GitHubDataCapture.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GitHubDataCapture.Infra.Repository
{
    public class GitHubContext : DbContext
    {
        public GitHubContext(DbContextOptions<GitHubContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().OwnsOne(x => x.Owner);
            modelBuilder.Entity<Item>().OwnsOne(x => x.License);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Item> Items { get; set; }
    }
}
