using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quota.Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class mig_init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserQuotes",
                columns: table => new
                {
                    Username = table.Column<string>(type: "text", nullable: false),
                    QuoteId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserQuotes", x => new { x.Username, x.QuoteId });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserQuotes");
        }
    }
}
