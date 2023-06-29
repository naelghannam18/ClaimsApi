namespace Domain.Exceptions;

public class FailedToUpdateClaimException : Exception
{
    private const string ExceptionMessage = "Failed To Update Claim";
    public FailedToUpdateClaimException() : base(ExceptionMessage)
    {       
    }
}
