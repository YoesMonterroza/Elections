using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elections.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddElectoralJourneyEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ElectoralJourneys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectoralJourneys", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElectoralJourneys_Date",
                table: "ElectoralJourneys",
                column: "Date",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElectoralJourneys");
        }
    }
}
