using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormRequestAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentIdToRequestInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentIdNumber",
                table: "RequestInfo",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "StudentFullName",
                table: "RequestInfo",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "FormType",
                table: "RequestInfo",
                newName: "FormRequested");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "RequestInfo",
                newName: "StudentIdNumber");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "RequestInfo",
                newName: "StudentFullName");

            migrationBuilder.RenameColumn(
                name: "FormRequested",
                table: "RequestInfo",
                newName: "FormType");
        }
    }
}
