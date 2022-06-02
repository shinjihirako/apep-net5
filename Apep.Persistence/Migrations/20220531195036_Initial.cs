using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Apep.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mediaItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mediaItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "mediaItems",
                columns: new[] { "Id", "Name", "Tag" },
                values: new object[] { new Guid("79ccc8c8-0e36-4d63-b9ad-459e6e49e0cd"), "Bruce Wayne", "Batman" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mediaItems");
        }
    }
}
