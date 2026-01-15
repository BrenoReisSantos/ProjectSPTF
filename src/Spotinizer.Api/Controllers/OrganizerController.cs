using Microsoft.AspNetCore.Mvc;
using Sptf.Domain.Dto;
using Sptf.Domain.Services;

namespace Sptf.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrganizerController(IOrganizerService organizerService) : ControllerBase
{
    private readonly IOrganizerService _organizerService = organizerService;

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateOrganizerRequestDto request)
    {
        var createdOrganizer = await _organizerService.CreateAsync(request);

        return Ok(createdOrganizer);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
    {
        var organizer = await _organizerService.GetByIdAsync(id);

        if (organizer == null)
        {
            return NotFound();
        }

        return Ok(organizer);
    }

    [HttpGet]
    public async Task<IActionResult> ListAllAsync()
    {
        var organizers = await _organizerService.ListAllAsync();
        return Ok(organizers);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateOrganizerRequestDto request)
    {
        var updatedOrganizer = await _organizerService.UpdateAsync(request);
        return Ok(updatedOrganizer);
    }
}