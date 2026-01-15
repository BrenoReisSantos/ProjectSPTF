using Sptf.Domain.Dto;
using Sptf.Domain.Models;

namespace Sptf.Domain.Services;

public interface IOrganizerService
{
    Task<Organizer> CreateAsync(CreateOrganizerRequestDto request);
    Task<IEnumerable<Organizer>> ListAllAsync();
    Task<Organizer?> GetByIdAsync(Guid id);
    Task<Organizer> UpdateAsync(UpdateOrganizerRequestDto request);
}