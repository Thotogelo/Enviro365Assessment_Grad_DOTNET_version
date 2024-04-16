using Microsoft.EntityFrameworkCore;

namespace Enviro365Assessment_Grad_DOTNET_version.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("FileName=environmentdb.sqlite");
    }

}