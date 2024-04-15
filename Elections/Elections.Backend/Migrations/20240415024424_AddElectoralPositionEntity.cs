using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elections.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddElectoralPositionEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ElectoralPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectoralPositions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElectoralPositions_Name",
                table: "ElectoralPositions",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElectoralPositions");
        }
    }
}
