using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SystemManagementMovie.Common.DataAccess;
using SystemManagementMovie.Moduls.UserIdentity.Validations;

namespace SystemManagementMovie.Common.Base.DI;

public static class DbContextRegistration
{
    public static WebApplicationBuilder AddDbContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<DataContext>(x =>
            x.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

        builder.Services.AddDbContext<AppCommandDbContext>(x =>
            x.UseNpgsql(builder.Configuration.GetConnectionString("Default")));
        
        builder.Services.AddDbContext<AppQueryDbContext>(x =>
            x.UseNpgsql(builder.Configuration.GetConnectionString("Default")));
        
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        builder.Services.AddValidatorsFromAssemblyContaining<CreateUserValidation>();
        
        return builder;
    }
}