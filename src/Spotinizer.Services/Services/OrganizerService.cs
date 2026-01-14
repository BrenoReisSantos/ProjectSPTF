using Sptf.Domain.Dto;
using Sptf.Domain.Models;
using Sptf.Domain.Repository;
using Sptf.Domain.Services;

namespace Spotinizer.Services.Services;

public class OrganizerService(IOrganizerRepository organizerRepository) : IOrganizerServices
{
    private readonly IOrganizerRepository _organizerRepository = organizerRepository;

    public async Task<Organizer> CreateOrganizer(CreateOrganizerRequestDto request)
    {
        var organizerToInsert = new Organizer
        {
            Name = request.Name,
            InputPlaylistId = request.InputPlaylistId,
            OutputPlaylistName = request.OutputPlaylistName,
        };

        var createdOrganizer = await _organizerRepository.CreateOrganizer(organizerToInsert);

        return createdOrganizer;
    }
}