using Sptf.Domain.Models;

namespace Sptf.Domain.Repository;

public interface IOrganizerRepository
{
    Task<Organizer> Create(Organizer organizer);
    Task<Organizer?> GetById(Guid id);
    Task<Organizer> UpdateAsync(Organizer organizer);
    Task<IEnumerable<Organizer>> ListAll();
}