using SystemManagementMovie.Common.Base;

namespace SystemManagementMovie.Moduls.UserIdentity.Entities;

public class User : BaseEntity
{
    public string FullName { get; set; } = null!;

    public int Age { get; set; }

    public string Email { get; set; } = null!;

    public bool HasPremium { get; set; }
}