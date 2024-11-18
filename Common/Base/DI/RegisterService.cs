using System.Reflection;
using SystemManagementMovie.Common.Base.Repository;
using SystemManagementMovie.Common.UOW;
using SystemManagementMovie.Moduls.Content.Entities;
using SystemManagementMovie.Moduls.Content.Repository;
using SystemManagementMovie.Moduls.Content.Services;
using SystemManagementMovie.Moduls.UserIdentity.Entities;

namespace SystemManagementMovie.Common.Base.DI;

public static class RegisterService
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        
        services.AddScoped<IGenericAddRepository<User>, GenericAddRepository<User>>();
        services.AddScoped<IGenericUpdateRepository<User>, GenericUpdateRepository<User>>();
        services.AddScoped<IGenericDeleteRepository<User>, GenericDeleteRepository<User>>();
        services.AddScoped<IGenericFindRepository<User>, GenericFindRepository<User>>();
        
        services.AddScoped<IGenericAddRepository<Admin>, GenericAddRepository<Admin>>();
        services.AddScoped<IGenericUpdateRepository<Admin>, GenericUpdateRepository<Admin>>();
        services.AddScoped<IGenericDeleteRepository<Admin>, GenericDeleteRepository<Admin>>();
        services.AddScoped<IGenericFindRepository<Admin>, GenericFindRepository<Admin>>();

        services.AddScoped<IGenericAddRepository<Content>, GenericAddRepository<Content>>();
        services.AddScoped<IGenericFindRepository<Content>, GenericFindRepository<Content>>();
        
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<IGenericAddRepository<Content>, GenericAddRepository<Content>>(); 
        services.AddScoped<IContentRepository, ContentRepository>();

        
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}