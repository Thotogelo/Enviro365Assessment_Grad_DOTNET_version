using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Enviro365Assessment_Grad_DOTNET_version.Model;

public class WasteModelConfig : IEntityTypeConfiguration<Waste>
{
    public void Configure(EntityTypeBuilder<Waste> builder)
    {
        builder.Property(x => x.Id);

        builder.Property(x => x.Category);

        builder.Property(x => x.Disposalguideline);

        builder.Property(x => x.Recyclingtips);
    }
}