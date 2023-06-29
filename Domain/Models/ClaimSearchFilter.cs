using Domain.Enums;

namespace Domain.Models;

public class ClaimSearchFilter
{
    public DateRange? Range { get; set; }

    public string? CardNumber { get; set; }

    public HospitalsEnum? Hospital { get; set; }

    public ClaimStatusEnum? ClaimStatus { get; set; }
}

public class DateRange
{
    public DateTime From { get; set; }

    public DateTime To { get; set; }
}