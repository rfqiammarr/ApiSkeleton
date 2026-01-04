namespace RifqiAmmarR.ApiSkeleton.Application.Common.Exceptions;

public class NoContentException : ApplicationException
{
    public NoContentException(string message) : base(message, 204) { }
}
