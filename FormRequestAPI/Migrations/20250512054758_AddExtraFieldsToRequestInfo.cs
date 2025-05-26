using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormRequestAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddExtraFieldsToRequestInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "RequestInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "RequestInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "RequestInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Program",
                table: "RequestInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PurposeOfRequest",
                table: "RequestInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "RequestInfo");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "RequestInfo");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "RequestInfo");

            migrationBuilder.DropColumn(
                name: "Program",
                table: "RequestInfo");

            migrationBuilder.DropColumn(
                name: "PurposeOfRequest",
                table: "RequestInfo");
        }
    }
}
