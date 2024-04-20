using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elections.Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zonings_VotingStations_VotingStationId",
                table: "Zonings");

            migrationBuilder.DropIndex(
                name: "IX_VotingStations_Name",
                table: "VotingStations");

            migrationBuilder.CreateIndex(
                name: "IX_VotingStations_Name_Code",
                table: "VotingStations",
                columns: new[] { "Name", "Code" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Zonings_VotingStations_VotingStationId",
                table: "Zonings",
                column: "VotingStationId",
                principalTable: "VotingStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zonings_VotingStations_VotingStationId",
                table: "Zonings");

            migrationBuilder.DropIndex(
                name: "IX_VotingStations_Name_Code",
                table: "VotingStations");

            migrationBuilder.CreateIndex(
                name: "IX_VotingStations_Name",
                table: "VotingStations",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Zonings_VotingStations_VotingStationId",
                table: "Zonings",
                column: "VotingStationId",
                principalTable: "VotingStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
