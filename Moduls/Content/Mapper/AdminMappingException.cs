using SystemManagementMovie.Moduls.Content.Commands.CommandRequest;
using SystemManagementMovie.Moduls.Content.Entities;
using SystemManagementMovie.Moduls.Content.Queries.ViewModels;
using SystemManagementMovie.Moduls.UserIdentity.Entities;

namespace SystemManagementMovie.Moduls.Content.Mapper;

public static class AdminMappingExtensions
{
    public static GetAdminVm ToReadInfo(this Admin admin)
    {
        return new()
        {
            Id = admin.Id,
            AdminBaseInfo = new()
            {
                FullName = admin.FullName,
                Age = admin.Age,
                CountryName = admin.CountryName,
            }
        };
    }
    
    public static GetAdminByIdVm ToReadByIdInfo(this Admin admin)
    {
        return new()
        {
            Id = admin.Id,
            AdminBaseInfo = new()
            {
                FullName = admin.FullName,
                Age = admin.Age,
                CountryName = admin.CountryName,
            }
        };
    }

    public static Admin ToAdmin(this CreateAdminRequest createRequest)
    {
        return new Admin
        {
            FullName = createRequest.AdminBaseInfo.FullName,
            Age = createRequest.AdminBaseInfo.Age,
            CountryName = createRequest.AdminBaseInfo.CountryName
        };
    }

    public static Admin ToUpdateAdmin(this Admin admin, UpdateAdminRequest updateRequest)
    {
        admin.FullName = updateRequest.AdminBaseInfo.FullName;
        admin.Age = updateRequest.AdminBaseInfo.Age;
        admin.CountryName = updateRequest.AdminBaseInfo.CountryName;
        admin.UpdatedAt = DateTime.UtcNow;

        return admin;
    }

    public static Admin ToDeletedAdmin(this Admin admin)
    {
        admin.IsDeleted = true;
        admin.DeletedAt = DateTime.UtcNow;
        admin.UpdatedAt = DateTime.UtcNow;

        return admin;
    }
}
