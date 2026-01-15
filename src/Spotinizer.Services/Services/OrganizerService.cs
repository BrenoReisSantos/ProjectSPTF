using Sptf.Domain.Dto;
using Sptf.Domain.Models;
using Sptf.Domain.Repository;
using Sptf.Domain.Services;

namespace Spotinizer.Services.Services;

public class OrganizerService(IOrganizerRepository organizerRepository) : IOrganizerService
{
    private readonly IOrganizerRepository _organizerRepository = organizerRepository;

    public async Task<Organizer> CreateAsync(CreateOrganizerRequestDto request)
    {
        var organizerToInsert = new Organizer
        {
            Name = request.Name,
            InputPlaylistId = request.InputPlaylistId,
            OutputPlaylistName = request.OutputPlaylistName,
            UserId = request.UserId
        };

        var createdOrganizer = await _organizerRepository.Create(organizerToInsert);

        return createdOrganizer;
    }

    public async Task<IEnumerable<Organizer>> ListAllAsync() => await _organizerRepository.ListAll();

    public async Task<Organizer?> GetByIdAsync(Guid id) => await _organizerRepository.GetById(id);

    public async Task<Organizer> UpdateAsync(UpdateOrganizerRequestDto request)
    {
        var changingOrganizer = await _organizerRepository.GetById(request.Id);
        if (changingOrganizer is null) throw new Exception("Organizer not found");

        var organizerToInsert = changingOrganizer with
        {
            Id = request.Id,
            Name = request.Name,
            InputPlaylistId = request.InputPlaylistId,
            OutputPlaylistName = request.OutputPlaylistName,
            UserId = request.UserId
        };

        var updatedOrganizer = await _organizerRepository.UpdateAsync(organizerToInsert);

        return updatedOrganizer;
    }
}