using ApiSkeleton.Application.Common.Responses;

namespace RifqiAmmarR.ApiSkeleton.Application.Common.Responses;

public class PaginatedListResponse<T> : Response
{
    public IReadOnlyList<T> Items { get; init; } = Array.Empty<T>();

    public int PageNumber { get; init; }
    public int PageSize { get; init; }

    public int TotalCount { get; init; }

    public int TotalPages =>
        (int)Math.Ceiling(TotalCount / (double)PageSize);

    public bool HasNextPage => PageNumber < TotalPages;
    public bool HasPreviousPage => PageNumber > 1;
}
