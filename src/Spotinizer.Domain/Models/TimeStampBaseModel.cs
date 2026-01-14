namespace Sptf.Domain.Models;

public record TimeStampBaseModel
{
    public DateTime CreationDate { get; init; }
    public DateTime? LastUpdateDate { get; set; }
}