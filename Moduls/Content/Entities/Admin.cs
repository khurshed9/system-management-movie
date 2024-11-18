using SystemManagementMovie.Common.Base;
using SystemManagementMovie.Moduls.Content.Constant;

namespace SystemManagementMovie.Moduls.Content.Entities;

public class Admin : BaseEntity
{
    public string FullName { get; set; } = null!;

    public int Age { get; set; }

    public string CountryName { get; set; } = null!;

    public string ContentName { get; set; } = ImageNames.Default;

    public ICollection<Content> Contents { get; set; } = [];
}