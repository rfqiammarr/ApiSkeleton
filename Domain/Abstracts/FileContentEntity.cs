using Domain.Abstracts;
using RifqiAmmarR.FinanTrackr.Domain.Interfaces;

namespace RifqiAmmarR.FinanTrackr.Domain.Abstracts;

public abstract class FileContentEntity : ModifiedEntity, IHasFile
{
    public string FileName { get; set; } = default!;
    public string FileContentType { get; set; } = default!;
    public long FileSize { get; set; }
    public string StorageFileId { get; set; } = default!;
}
