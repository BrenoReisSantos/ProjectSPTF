namespace Sptf.Domain.Models;

public class FilterOperation: TimeStampBaseModel
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public List<OperationParameter>? Parameters { get; init; }

    public List<Organizer>? Organizers { get; init; }
}