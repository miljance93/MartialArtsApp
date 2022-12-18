using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class ChangeUserFollowingsEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowings_AspNetUsers_ClientId",
                table: "UserFollowings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowings_AspNetUsers_CoachId",
                table: "UserFollowings");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "UserFollowings",
                newName: "TargetId");

            migrationBuilder.RenameColumn(
                name: "CoachId",
                table: "UserFollowings",
                newName: "ObserverId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFollowings_ClientId",
                table: "UserFollowings",
                newName: "IX_UserFollowings_TargetId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowings_AspNetUsers_ObserverId",
                table: "UserFollowings",
                column: "ObserverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowings_AspNetUsers_TargetId",
                table: "UserFollowings",
                column: "TargetId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowings_AspNetUsers_ObserverId",
                table: "UserFollowings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowings_AspNetUsers_TargetId",
                table: "UserFollowings");

            migrationBuilder.RenameColumn(
                name: "TargetId",
                table: "UserFollowings",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "ObserverId",
                table: "UserFollowings",
                newName: "CoachId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFollowings_TargetId",
                table: "UserFollowings",
                newName: "IX_UserFollowings_ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowings_AspNetUsers_ClientId",
                table: "UserFollowings",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowings_AspNetUsers_CoachId",
                table: "UserFollowings",
                column: "CoachId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
