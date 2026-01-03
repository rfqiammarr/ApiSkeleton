namespace ApiSkeleton.Application.Common.Exceptions;

public class ForbiddenException : ApplicationException
{
    public ForbiddenException(string message) : base(message, 403) { }
}
