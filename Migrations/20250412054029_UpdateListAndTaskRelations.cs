using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace To_Do_List.Migrations
{
    /// <inheritdoc />
    public partial class UpdateListAndTaskRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lists_Users_user_IdId",
                table: "Lists");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Lists_list_IdId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "dueDate",
                table: "Tasks",
                newName: "DueDate");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Tasks",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "list_IdId",
                table: "Tasks",
                newName: "ListId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_list_IdId",
                table: "Tasks",
                newName: "IX_Tasks_ListId");

            migrationBuilder.RenameColumn(
                name: "user_IdId",
                table: "Lists",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Lists_user_IdId",
                table: "Lists",
                newName: "IX_Lists_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lists_Users_UserId",
                table: "Lists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Lists_ListId",
                table: "Tasks",
                column: "ListId",
                principalTable: "Lists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lists_Users_UserId",
                table: "Lists");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Lists_ListId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "DueDate",
                table: "Tasks",
                newName: "dueDate");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Tasks",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "ListId",
                table: "Tasks",
                newName: "list_IdId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_ListId",
                table: "Tasks",
                newName: "IX_Tasks_list_IdId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Lists",
                newName: "user_IdId");

            migrationBuilder.RenameIndex(
                name: "IX_Lists_UserId",
                table: "Lists",
                newName: "IX_Lists_user_IdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lists_Users_user_IdId",
                table: "Lists",
                column: "user_IdId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Lists_list_IdId",
                table: "Tasks",
                column: "list_IdId",
                principalTable: "Lists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
