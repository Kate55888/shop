

using ApplicationName.Domain.Models;
using ApplicationName.Domain.Models.Auth;
using Microsoft.EntityFrameworkCore;

namespace ApplicationName.Infrastructure.Persistence;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<Item?> Items { get; set; }

    public DbSet<User?> Users { get; set; }
}