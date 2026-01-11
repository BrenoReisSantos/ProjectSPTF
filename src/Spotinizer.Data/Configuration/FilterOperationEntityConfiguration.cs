using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sptf.Domain.Models;

namespace Sptf.Data.Configuration;

public class FilterOperationEntityConfiguration : IEntityTypeConfiguration<FilterOperation>
{
    public void Configure(EntityTypeBuilder<FilterOperation> builder)
    {
        builder.Property(o => o.Name).IsRequired();
        builder.HasIndex(o => o.Name).IsUnique();

        builder.HasMany(f => f.Parameters).WithOne();
        builder.HasMany(f => f.Organizers).WithMany(o => o.FilterOperations);
    }
}