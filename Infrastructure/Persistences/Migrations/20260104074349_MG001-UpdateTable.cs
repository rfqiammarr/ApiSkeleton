using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RifqiAmmarR.ApiSKeleton.Infrastructure.Persistences.Migrations
{
    /// <inheritdoc />
    public partial class MG001UpdateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
