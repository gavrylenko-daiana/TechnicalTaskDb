using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL;

public class AppContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectTask> ProjectTasks { get; set; }
    public DbSet<TaskFile> TaskFiles { get; set; }
    // public DbSet<ProjectTask> ProjectTasks { get; set; }

    public AppContext(DbContextOptions<AppContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        optionsBuilder.UseSqlServer(@"Server=localhost;Database=ProjectManager;User=sa;Password=reallyStrongPwd123;TrustServerCertificate=True;");
    }
}