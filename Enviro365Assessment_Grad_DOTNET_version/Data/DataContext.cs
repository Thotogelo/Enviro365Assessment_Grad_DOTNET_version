using Enviro365Assessment_Grad_DOTNET_version.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Enviro365Assessment_Grad_DOTNET_version.Data;

public class DataContext : DbContext
{
    public DbSet<Waste> Wastes { get; set; }

    public DataContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("FileName=environmentdb.sqlite");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new WasteModelConfig().Configure(modelBuilder.Entity<Waste>());
    }
}