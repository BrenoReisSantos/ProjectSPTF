namespace Sptf.Domain.Models;

public record User : TimeStampBaseModel
{
    public required Guid Id { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }

    public List<Organizer>? Organizers { get; init; }
}