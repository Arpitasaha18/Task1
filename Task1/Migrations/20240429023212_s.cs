using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task1.Migrations
{
    /// <inheritdoc />
    public partial class s : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "ChangeRequestForms");

            migrationBuilder.RenameColumn(
                name: "ChangeRequestDetails",
                table: "ChangeRequestForms",
                newName: "changeRequestDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChangeRequestForms",
                table: "ChangeRequestForms",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChangeRequestForms",
                table: "ChangeRequestForms");

            migrationBuilder.RenameTable(
                name: "ChangeRequestForms",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "changeRequestDetails",
                table: "Users",
                newName: "ChangeRequestDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "id");
        }
    }
}
