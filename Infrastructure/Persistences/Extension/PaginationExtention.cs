using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.ApiSkeleton.Application.Common.Responses;

namespace RifqiAmmarR.ApiSkeleton.Application.Common.Extensions;

public static class PaginationExtensions
{
    public static async Task<PaginatedListResponse<T>> ToPaginatedListAsync<T>(
        this IQueryable<T> query,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken)
    {
        if (pageNumber <= 0)
            pageNumber = 1;

        if (pageSize <= 0)
            pageSize = 10;

        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new PaginatedListResponse<T>
        {
            Items = items,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = totalCount
        };
    }
}