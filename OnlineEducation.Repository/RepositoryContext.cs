using Microsoft.EntityFrameworkCore;
using OnlineEducation.Model;

namespace OnlineEducation.Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options)
    {
        this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }
    
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Cource> Cources { get; set; }
    public DbSet<CourceGroup> CourceGroups { get; set; }
    public DbSet<CourceLesson> CourceLessons { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Test> Tests { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserCourceGroup> UserCourceGroups { get; set; }
}