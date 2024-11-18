using Microsoft.EntityFrameworkCore;
using SystemManagementMovie.Moduls.Content.Entities;
using SystemManagementMovie.Moduls.UserIdentity.Entities;

namespace SystemManagementMovie.Common.DataAccess;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    public DbSet<Admin> Admins { get; set; }

    public DbSet<Content> Contents { get; set; }
}