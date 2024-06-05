using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressNews.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeletedToSubscriptionType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SubscriptionTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SubscriptionTypes");
        }
    }
}
