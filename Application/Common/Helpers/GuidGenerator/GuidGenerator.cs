
namespace RifqiAmmarR.ApiSkeleton.Application.Common.Helpers.GuidGenerator;

public static class GuidGenerator
{
    public static Guid New()
    {
        return Guid.CreateVersion7();
    }
}
