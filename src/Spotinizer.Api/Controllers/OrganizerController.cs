using Microsoft.AspNetCore.Mvc;
using Sptf.Domain.Dto;
using Sptf.Domain.Services;

namespace Sptf.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrganizerController(IOrganizerServices organizerServices) : ControllerBase
{
    private readonly IOrganizerServices _organizerServices = organizerServices;
    
    [HttpPost]
    public async Task<IActionResult> CreateOrganizer(CreateOrganizerRequestDto request)
    {
        var createdOrganizer = await _organizerServices.CreateOrganizer(request);
        
        return Ok(createdOrganizer);
    }
}