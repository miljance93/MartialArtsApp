using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class CommentEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_MartialArts_MartialArtId",
                table: "Comments");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_MartialArts_MartialArtId",
                table: "Comments",
                column: "MartialArtId",
                principalTable: "MartialArts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_MartialArts_MartialArtId",
                table: "Comments");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_MartialArts_MartialArtId",
                table: "Comments",
                column: "MartialArtId",
                principalTable: "MartialArts",
                principalColumn: "Id");
        }
    }
}
