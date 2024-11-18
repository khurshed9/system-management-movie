using Microsoft.EntityFrameworkCore;

namespace SystemManagementMovie.Common.DataAccess;

public sealed class AppQueryDbContext(DbContextOptions<DataContext> options) : DataContext(options);