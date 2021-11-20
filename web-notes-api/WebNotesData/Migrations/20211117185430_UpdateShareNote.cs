using Microsoft.EntityFrameworkCore.Migrations;

namespace WebNotesData.Migrations
{
    public partial class UpdateShareNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NoteId",
                table: "ShareNotes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShareNotes_NoteId",
                table: "ShareNotes",
                column: "NoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShareNotes_Notes_NoteId",
                table: "ShareNotes",
                column: "NoteId",
                principalTable: "Notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShareNotes_Notes_NoteId",
                table: "ShareNotes");

            migrationBuilder.DropIndex(
                name: "IX_ShareNotes_NoteId",
                table: "ShareNotes");

            migrationBuilder.DropColumn(
                name: "NoteId",
                table: "ShareNotes");
        }
    }
}
