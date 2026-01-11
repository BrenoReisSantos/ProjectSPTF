namespace Sptf.Domain.Models;

public class Organizer : TimeStampBaseModel
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
    public required string OutputPlaylistName { get; init; }
    public string? OutputPlaylistId { get; init; }
    public required string InputPlaylistId { get; init; }

    public List<FilterOperation>? FilterOperations { get; init; }

    public required Guid UserId { get; init; }
    public User? User { get; init; }
}