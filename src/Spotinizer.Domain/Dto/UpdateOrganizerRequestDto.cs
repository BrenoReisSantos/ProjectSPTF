namespace Sptf.Domain.Dto;

public record UpdateOrganizerRequestDto
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string OutputPlaylistName { get; init; }
    public required string InputPlaylistId { get; init; }
    public required Guid UserId { get; init; }
}