using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XArbete.Services.Migrations
{
    public partial class gg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_KennelContentSections_KennelContents_KennelContentId",
            //    table: "KennelContentSections");
            migrationBuilder.RenameColumn("KennelContentId", "KennelContentSections", "ContentId");
            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_KennelContentSections",
            //    table: "KennelContentSections");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_KennelContents",
            //    table: "KennelContents");
            
 
            //migrationBuilder.DropColumn(
            //    name: "KennelContentId",
            //    table: "KennelContentSections");

            migrationBuilder.RenameTable(
                name: "KennelContentSections",
                newName: "ContentSections");

            migrationBuilder.RenameTable(
                name: "KennelContents",
                newName: "Contents");

            migrationBuilder.RenameTable(
    name: "Dogs",
    newName: "CustomerDogs");


            //migrationBuilder.AddColumn<int>(
            //    name: "ContentId",
            //    table: "ContentSections",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_ContentSections",
            //    table: "ContentSections",
            //    column: "Id");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_Contents",
            //    table: "Contents",
            //    column: "ID");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    NumberAvailable = table.Column<int>(nullable: false),
                    MaximumParticipants = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    DogId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCourses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "CustomerCourses");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_ContentSections",
            //    table: "ContentSections");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_Contents",
            //    table: "Contents");

            //migrationBuilder.DropColumn(
            //    name: "DateOfBirth",
            //    table: "Dogs");

            //migrationBuilder.DropColumn(
            //    name: "ContentId",
            //    table: "ContentSections");

            migrationBuilder.RenameTable(
                name: "ContentSections",
                newName: "KennelContentSections");

            migrationBuilder.RenameTable(
                name: "Contents",
                newName: "KennelContents");

            migrationBuilder.AddColumn<int>(
                name: "KennelContentId",
                table: "KennelContentSections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_KennelContentSections",
                table: "KennelContentSections",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KennelContents",
                table: "KennelContents",
                column: "ID");
        }
    }
}
