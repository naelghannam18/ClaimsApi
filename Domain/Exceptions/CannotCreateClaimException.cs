namespace Domain.Exceptions;

public class CannotCreateClaimException : Exception
{
    public CannotCreateClaimException(string message) : base(message)
    {
        
    }
}
