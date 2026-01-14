using Sptf.Domain.Models;

namespace Sptf.Domain.Repository;

public interface IOrganizerRepository
{
    Task<Organizer> CreateOrganizer(Organizer organizer);
    Task<Organizer?> GetOrganizerById(int id);
    Task<Organizer> UpdateOrganizer(Organizer organizer);
}