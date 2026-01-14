using Sptf.Data;
using Sptf.Domain.Models;
using Sptf.Domain.Repository;

namespace Spotinizer.Repository;

public class OrganizerRepository(SpotinizerContext spotinizerContext) : IOrganizerRepository
{
    private readonly SpotinizerContext _spotinizerContext = spotinizerContext;

    public async Task<Organizer> CreateOrganizer(Organizer organizer)
    {
        var insertingOrganizer = organizer with
        {
            CreationDate = DateTime.UtcNow
        };

        _spotinizerContext.Organizers.Add(insertingOrganizer);

        await _spotinizerContext.SaveChangesAsync();

        return insertingOrganizer;
    }

    public async Task<Organizer?> GetOrganizerById(int id) => await _spotinizerContext.Organizers.FindAsync(id);

    public async Task<Organizer> UpdateOrganizer(Organizer organizer)
    {
        var updatingOrganizer = organizer with
        {
            LastUpdateDate = DateTime.UtcNow
        };

        _spotinizerContext.Organizers.Update(updatingOrganizer);

        await _spotinizerContext.SaveChangesAsync();

        return updatingOrganizer;
    }
}