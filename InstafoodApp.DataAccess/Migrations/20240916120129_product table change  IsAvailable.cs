using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstafoodApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class producttablechangeIsAvailable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "OrderStatusId",
                keyValue: 5,
                column: "Status",
                value: "Out for Delivery");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "OrderStatusId",
                keyValue: 5,
                column: "Status",
                value: "Out of Delivery");
        }
    }
}
