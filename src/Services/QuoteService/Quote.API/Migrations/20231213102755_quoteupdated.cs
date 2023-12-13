using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quote.API.Migrations
{
    /// <inheritdoc />
    public partial class quoteupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Quotes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Quotes",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
