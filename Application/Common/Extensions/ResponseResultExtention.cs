using ApiSkeleton.Application.Common.Responses;

namespace ApiSkeleton.Common.Extensions;


public static class ResponseResultExtension
{
    public static ResponseResult<T> ToResponseResult<T>(this T source)
    {
        return new ResponseResult<T> { Result = source };
    }
}
