using Microsoft.EntityFrameworkCore;
using TodoAppBe.Entities;

namespace TodoAppBe.Database;

public class ApplicationContext:DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<TaskEntity>Tasks { get; set; }
}