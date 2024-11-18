using SystemManagementMovie.Moduls.UserIdentity.Commands.CommandRequest;
using SystemManagementMovie.Moduls.UserIdentity.Entities;
using SystemManagementMovie.Moduls.UserIdentity.Queries.ViewModels;

namespace SystemManagementMovie.Moduls.UserIdentity.Mapper;

public static class UserMappingExtensions
{
    
    public static GetUserVm ToReadInfo(this User user)
    {
        return new()
        {
            Id = user.Id,
            UserBaseInfo = new()
            {
                FullName = user.FullName,
                Age = user.Age,
                Email = user.Email,
                HasPremium = user.HasPremium,
            }
        };
    }
    
    public static GetUserByIdVm ToReadByIdInfo(this User user)
    {
        return new()
        {
            Id = user.Id,
            UserBaseInfo = new()
            {
                FullName = user.FullName,
                Age = user.Age,
                Email = user.Email,
                HasPremium = user.HasPremium,
            }
        };
    }

    public static User ToUser(this CreateUserRequest createInfo)
    {
        return new()
        {
            FullName = createInfo.UserBaseInfo.FullName,
            Age = createInfo.UserBaseInfo.Age,
            Email = createInfo.UserBaseInfo.Email,
            HasPremium = createInfo.UserBaseInfo.HasPremium,
        };
    }

    public static User ToUpdateUser(this User user ,UpdateUserRequest updateInfo)
    {
        user.FullName = updateInfo.UserBaseInfo.FullName;
        user.Age = updateInfo.UserBaseInfo.Age;
        user.Email = updateInfo.UserBaseInfo.Email;
        user.HasPremium = updateInfo.UserBaseInfo.HasPremium;
        user.Version++;
        user.UpdatedAt = DateTime.UtcNow;
        return user;
    }

    public static User ToDeletedUser(this User user, UpdateUserRequest request)
    {
        user.IsDeleted = true;
        user.DeletedAt = DateTime.UtcNow;
        user.UpdatedAt = DateTime.UtcNow;
        user.Version++;
        return user;
    }
}