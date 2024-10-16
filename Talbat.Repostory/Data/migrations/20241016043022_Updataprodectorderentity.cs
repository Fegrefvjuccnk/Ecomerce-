using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Talbat.Repostory.Data.migrations
{
    /// <inheritdoc />
    public partial class Updataprodectorderentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Deliveryitems_deliveryitemId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "deliveryitemId",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int?");

            migrationBuilder.AddColumn<string>(
                name: "productorder_Descrption",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Deliveryitems_deliveryitemId",
                table: "Orders",
                column: "deliveryitemId",
                principalTable: "Deliveryitems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Deliveryitems_deliveryitemId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "productorder_Descrption",
                table: "OrderItems");

            migrationBuilder.AlterColumn<int>(
                name: "deliveryitemId",
                table: "Orders",
                type: "int?",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Deliveryitems_deliveryitemId",
                table: "Orders",
                column: "deliveryitemId",
                principalTable: "Deliveryitems",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
