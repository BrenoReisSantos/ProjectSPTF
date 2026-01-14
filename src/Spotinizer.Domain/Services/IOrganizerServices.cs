using Sptf.Domain.Dto;
using Sptf.Domain.Models;

namespace Sptf.Domain.Services;

public interface IOrganizerServices
{
    Task<Organizer> CreateOrganizer(CreateOrganizerRequestDto request);
}