using Microsoft.EntityFrameworkCore.Migrations;

namespace ObligatorioDA2.EntityFrameworkCore.Migrations
{
    public partial class AddForecastsToUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "WeatherForecasts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeatherForecasts_UserId",
                table: "WeatherForecasts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherForecasts_Users_UserId",
                table: "WeatherForecasts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherForecasts_Users_UserId",
                table: "WeatherForecasts");

            migrationBuilder.DropIndex(
                name: "IX_WeatherForecasts_UserId",
                table: "WeatherForecasts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "WeatherForecasts");
        }
    }
}
