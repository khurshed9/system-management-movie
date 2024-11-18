namespace SystemManagementMovie.Moduls.UserIdentity.Entities;

public readonly record struct UserBaseInfo(
    string FullName,
    int Age,
    string Email,
    bool HasPremium);