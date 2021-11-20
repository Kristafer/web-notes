using Microsoft.EntityFrameworkCore.Migrations;

namespace WebNotesData.Migrations
{
    public partial class UpdateNote1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBookmark",
                table: "Notes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBookmark",
                table: "Notes");
        }
    }
}
