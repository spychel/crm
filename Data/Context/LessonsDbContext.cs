using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Data.Context;

public class LessonsDbContext(
    DbContextOptions<LessonsDbContext> options) 
    : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
