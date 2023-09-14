using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedMeasureUnitSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeasureUnits",
                columns: table => new
                {
                    MeasureUnitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Shortcut = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasureUnits", x => x.MeasureUnitId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeasureUnits");
        }
    }
}
