namespace Sptf.Domain.Models;

public class TimeStampBaseModel
{
    public DateTime CreationDate { get; init; }
    public DateTime? LastUpdateDate { get; set; }
}