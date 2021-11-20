using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebNotesData.Migrations
{
    public partial class AddShareNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Note_Users_UserId",
                table: "Note");

            migrationBuilder.DropForeignKey(
                name: "FK_NoteTag_Note_NoteId",
                table: "NoteTag");

            migrationBuilder.DropForeignKey(
                name: "FK_NoteTag_Tag_TagId",
                table: "NoteTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NoteTag",
                table: "NoteTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Note",
                table: "Note");

            migrationBuilder.RenameTable(
                name: "Tag",
                newName: "Tags");

            migrationBuilder.RenameTable(
                name: "NoteTag",
                newName: "NoteTags");

            migrationBuilder.RenameTable(
                name: "Note",
                newName: "Notes");

            migrationBuilder.RenameIndex(
                name: "IX_NoteTag_TagId",
                table: "NoteTags",
                newName: "IX_NoteTags_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_NoteTag_NoteId",
                table: "NoteTags",
                newName: "IX_NoteTags_NoteId");

            migrationBuilder.RenameIndex(
                name: "IX_Note_UserId",
                table: "Notes",
                newName: "IX_Notes_UserId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NoteTags",
                table: "NoteTags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notes",
                table: "Notes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ShareNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InactivateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShareNotes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_UserId",
                table: "Tags",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Users_UserId",
                table: "Notes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NoteTags_Notes_NoteId",
                table: "NoteTags",
                column: "NoteId",
                principalTable: "Notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NoteTags_Tags_TagId",
                table: "NoteTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Users_UserId",
                table: "Tags",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Users_UserId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_NoteTags_Notes_NoteId",
                table: "NoteTags");

            migrationBuilder.DropForeignKey(
                name: "FK_NoteTags_Tags_TagId",
                table: "NoteTags");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Users_UserId",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "ShareNotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_UserId",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NoteTags",
                table: "NoteTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tags");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Tag");

            migrationBuilder.RenameTable(
                name: "NoteTags",
                newName: "NoteTag");

            migrationBuilder.RenameTable(
                name: "Notes",
                newName: "Note");

            migrationBuilder.RenameIndex(
                name: "IX_NoteTags_TagId",
                table: "NoteTag",
                newName: "IX_NoteTag_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_NoteTags_NoteId",
                table: "NoteTag",
                newName: "IX_NoteTag_NoteId");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_UserId",
                table: "Note",
                newName: "IX_Note_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NoteTag",
                table: "NoteTag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Note",
                table: "Note",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Note_Users_UserId",
                table: "Note",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NoteTag_Note_NoteId",
                table: "NoteTag",
                column: "NoteId",
                principalTable: "Note",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NoteTag_Tag_TagId",
                table: "NoteTag",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
