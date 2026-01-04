namespace RifqiAmmarR.ApiSkeleton.Application.Common.Exceptions;
// Base class for all exceptions
public class ApplicationException(string message, int statusCode) : Exception(message)
{
    public int StatusCode { get; } = statusCode;
}

public class InternalServerErrorException(string message) : ApplicationException(message, 500)
{
}

public class UnauthorizedException(string message) : ApplicationException(message, 401)
{
}
