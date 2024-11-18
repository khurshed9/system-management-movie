using SystemManagementMovie.Common.Base;
using SystemManagementMovie.Moduls.Content.Enums;
using ContentType = System.Net.Mime.ContentType;

namespace SystemManagementMovie.Moduls.Content.Entities;

public class Content : BaseEntity
{
    public string Title { get; set; } = null!;

    public string FileName { get; set; } = null!;

    public string FilePath { get; set; } = null!;

    public ContentTypes Type { get; set; }

    public DateTime UploadDate { get; set; }

    public int AdminId { get; set; }
    public Admin Admin { get; set; } = null!;
}