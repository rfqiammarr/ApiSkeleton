namespace RifqiAmmarR.ApiSkeleton.Application.Common.Exceptions;

public class NotFoundException : ApplicationException
{
    public NotFoundException(string message) : base(message, 404) { }
}
