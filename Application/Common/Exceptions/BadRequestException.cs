namespace ApiSkeleton.Application.Common.Exceptions;

public class BadRequestException(string message) : ApplicationException(message, 400)
{
}
