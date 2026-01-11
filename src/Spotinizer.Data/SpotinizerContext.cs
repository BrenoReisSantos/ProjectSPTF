using Microsoft.EntityFrameworkCore;
using Sptf.Data.Configuration;
using Sptf.Domain.Models;

namespace Sptf.Data;

public class SpotinizerContext : DbContext
{
    private readonly DbContextOptions<SpotinizerContext> _options;

    public DbSet<User> Users { get; set; }
    public DbSet<Organizer> Organizers { get; set; }
    public DbSet<FilterOperation> FilterOperations { get; set; }
    public DbSet<OperationParameter> OperationsParameters { get; set; }
    public DbSet<OperationParameterType> OperationParameterTypes { get; set; }

    public SpotinizerContext(DbContextOptions<SpotinizerContext> options) : base(options)
    {
        _options = options;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserEntityConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}