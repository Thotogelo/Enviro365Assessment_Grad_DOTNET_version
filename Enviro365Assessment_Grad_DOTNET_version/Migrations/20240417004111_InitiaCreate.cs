using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Enviro365Assessment_Grad_DOTNET_version.Migrations
{
    /// <inheritdoc />
    public partial class InitiaCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Waste",
                columns: table => new
                {
                    waste_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    waste_category = table.Column<string>(type: "varchar(10)", nullable: false),
                    disposal_guideline = table.Column<string>(type: "varchar(50)", nullable: false),
                    recycling_tips = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waste", x => x.waste_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Waste");
        }
    }
}
