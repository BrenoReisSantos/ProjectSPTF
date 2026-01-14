namespace Sptf.Domain.Dto;

public record CreateOrganizerRequestDto
{
    public required string Name { get; init; }
    public required string OutputPlaylistName { get; init; }
    public required string InputPlaylistId { get; init; }
}