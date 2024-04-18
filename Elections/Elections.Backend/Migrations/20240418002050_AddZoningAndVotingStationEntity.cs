using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elections.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddZoningAndVotingStationEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VotingStations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotingStations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zonings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZoningNumber = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    VotingStationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zonings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zonings_VotingStations_VotingStationId",
                        column: x => x.VotingStationId,
                        principalTable: "VotingStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VotingStations_Name",
                table: "VotingStations",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zonings_VotingStationId_ZoningNumber",
                table: "Zonings",
                columns: new[] { "VotingStationId", "ZoningNumber" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zonings");

            migrationBuilder.DropTable(
                name: "VotingStations");
        }
    }
}
