using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sptf.Domain.Models;

namespace Sptf.Data.Configuration;

public class OrganizerEntityConfiguration : IEntityTypeConfiguration<Organizer>
{
    public void Configure(EntityTypeBuilder<Organizer> builder)
    {
        builder.Property(o => o.Name).IsRequired();
        builder.Property(o => o.OutputPlaylistName).IsRequired();
        builder.Property(o => o.InputPlaylistId).IsRequired();

        builder.HasOne(o => o.User).WithMany(u => u.Organizers).HasForeignKey(o => o.UserId);
        builder.HasMany(o => o.FilterOperations).WithMany(f => f.Organizers);
    }
}