using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task1.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameModelChangeRequestForm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_ChangeRequestForms_Employees_EmpId",
            //    table: "ChangeRequestForms");

            migrationBuilder.DropColumn(
                name: "RequestBy",
                table: "ChangeRequestForms");

            migrationBuilder.RenameColumn(
                name: "EmpId",
                table: "ChangeRequestForms",
                newName: "RequestById");

            migrationBuilder.RenameIndex(
                name: "IX_ChangeRequestForms_EmpId",
                table: "ChangeRequestForms",
                newName: "IX_ChangeRequestForms_RequestById");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "ChangeRequestForms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ReviewById",
                table: "ChangeRequestForms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ChangeRequestForms_ReviewById",
                table: "ChangeRequestForms",
                column: "ReviewById");

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeRequestForms_Employees_RequestById",
                table: "ChangeRequestForms",
                column: "RequestById",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeRequestForms_Employees_ReviewById",
                table: "ChangeRequestForms",
                column: "ReviewById",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChangeRequestForms_Employees_RequestById",
                table: "ChangeRequestForms");

            migrationBuilder.DropForeignKey(
                name: "FK_ChangeRequestForms_Employees_ReviewById",
                table: "ChangeRequestForms");

            migrationBuilder.DropIndex(
                name: "IX_ChangeRequestForms_ReviewById",
                table: "ChangeRequestForms");

            migrationBuilder.DropColumn(
                name: "ReviewById",
                table: "ChangeRequestForms");

            migrationBuilder.RenameColumn(
                name: "RequestById",
                table: "ChangeRequestForms",
                newName: "EmpId");

            migrationBuilder.RenameIndex(
                name: "IX_ChangeRequestForms_RequestById",
                table: "ChangeRequestForms",
                newName: "IX_ChangeRequestForms_EmpId");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "ChangeRequestForms",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "RequestBy",
                table: "ChangeRequestForms",
                type: "nvarchar(max)",
                nullable: true);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ChangeRequestForms_Employees_EmpId",
            //    table: "ChangeRequestForms",
            //    column: "EmpId",
            //    principalTable: "Employees",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
