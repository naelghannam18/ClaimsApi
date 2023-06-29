namespace Domain.Exceptions;

public class ClaimNotFoundExpection : Exception
{
    public ClaimNotFoundExpection() :base()
    {
        
    }

    public ClaimNotFoundExpection(string message) : base(message)
    {
        
    }
}
