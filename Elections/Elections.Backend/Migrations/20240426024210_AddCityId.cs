using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elections.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddCityId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "VotingStations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VotingStations_CityId",
                table: "VotingStations",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_VotingStations_Cities_CityId",
                table: "VotingStations",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VotingStations_Cities_CityId",
                table: "VotingStations");

            migrationBuilder.DropIndex(
                name: "IX_VotingStations_CityId",
                table: "VotingStations");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "VotingStations");
        }
    }
}
