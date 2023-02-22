using Microsoft.EntityFrameworkCore;
using TodoAppBe.Domain;
using TodoAppBe.Entities;
using TodoAppBe.Entities.Domain;

namespace TodoAppBe.Database;

public class ApplicationContext:DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<TTask> Tasks { get; set; }
}