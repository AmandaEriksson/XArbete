using Microsoft.EntityFrameworkCore.Migrations;

namespace XArbete.Services.Migrations
{
    public partial class removeisbreedkennecntets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBreed",
                table: "KennelContents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBreed",
                table: "KennelContents",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
