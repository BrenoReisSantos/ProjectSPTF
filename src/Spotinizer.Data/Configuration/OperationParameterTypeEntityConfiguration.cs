using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualBasic.CompilerServices;
using Sptf.Domain.Models;
using Sptf.Domain.Models.Values;

namespace Sptf.Data.Configuration;

public class OperationParameterTypeEntityConfiguration : IEntityTypeConfiguration<OperationParameterType>
{
    public void Configure(EntityTypeBuilder<OperationParameterType> builder)
    {
        builder.Property(p => p.Name).IsRequired();
        builder.HasIndex(p => p.Name).IsUnique();

        foreach (var operationParameterType in Enum.GetValues<OperationParameterTypeEnum>())
            builder.HasData(new OperationParameterType
                { Id = (int)operationParameterType, Name = operationParameterType.ToString() });
    }
}