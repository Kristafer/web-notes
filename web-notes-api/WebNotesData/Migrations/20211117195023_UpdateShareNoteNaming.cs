using Microsoft.EntityFrameworkCore.Migrations;

namespace WebNotesData.Migrations
{
    public partial class UpdateShareNoteNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InactivateDateTime",
                table: "ShareNotes",
                newName: "InactivatedDateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InactivatedDateTime",
                table: "ShareNotes",
                newName: "InactivateDateTime");
        }
    }
}
