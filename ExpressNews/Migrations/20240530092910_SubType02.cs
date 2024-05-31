using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressNews.Migrations
{
    /// <inheritdoc />
    public partial class SubType02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubscriptionTypeName",
                table: "Subscriptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubscriptionTypeName",
                table: "Subscriptions");
        }
    }
}
