using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sptf.Domain.Models;

namespace Sptf.Data.Configuration;

public class OperationParameterEntityConfiguration : IEntityTypeConfiguration<OperationParameter>
{
    public void Configure(EntityTypeBuilder<OperationParameter> builder)
    {
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.SequencePosition).IsRequired();
        builder.HasIndex(p => new { p.Id, p.SequencePosition }).IsUnique();

        builder.HasOne(p => p.Type).WithMany();
        builder.HasOne<FilterOperation>().WithMany(f => f.Parameters);
    }
}