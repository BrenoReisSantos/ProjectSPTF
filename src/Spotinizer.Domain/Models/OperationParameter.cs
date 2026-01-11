namespace Sptf.Domain.Models;

public class OperationParameter: TimeStampBaseModel
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required ushort SequencePosition { get; init; }
    public bool IsList { get; init; }

    public required OperationParameterType Type { get; init; }
}