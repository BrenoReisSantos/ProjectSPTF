namespace Sptf.Domain.Models;

public record OperationParameterType
{
    public int Id { get; init; }
    public required string Name { get; init; }
}