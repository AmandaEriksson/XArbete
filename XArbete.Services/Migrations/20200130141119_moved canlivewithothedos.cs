using Microsoft.EntityFrameworkCore.Migrations;

namespace XArbete.Services.Migrations
{
    public partial class movedcanlivewithothedos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropColumn(
                name: "CanLiveWithOtherDogs",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "Other",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "Ras",
                table: "Dogs");

            migrationBuilder.AddColumn<bool>(
                name: "CanLiveWithOtherDogs",
                table: "HotelBookings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Breed",
                table: "Dogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanLiveWithOtherDogs",
                table: "HotelBookings");

            migrationBuilder.DropColumn(
                name: "Breed",
                table: "Dogs");

            migrationBuilder.AddColumn<bool>(
                name: "CanLiveWithOtherDogs",
                table: "Dogs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Other",
                table: "Dogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ras",
                table: "Dogs",
                type: "nvarchar(max)",
                nullable: true);

        }
    }
}
