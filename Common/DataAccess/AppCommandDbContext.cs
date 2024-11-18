using Microsoft.EntityFrameworkCore;

namespace SystemManagementMovie.Common.DataAccess;

public sealed class AppCommandDbContext(DbContextOptions<DataContext> options) : DataContext(options);