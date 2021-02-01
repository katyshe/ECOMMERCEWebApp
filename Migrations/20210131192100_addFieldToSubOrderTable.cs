using Microsoft.EntityFrameworkCore.Migrations;

namespace ECOMMERCEWebApp.Migrations
{
    public partial class addFieldToSubOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Products_ProductId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Items",
                newName: "productId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_ProductId",
                table: "Items",
                newName: "IX_Items_productId");

            migrationBuilder.AlterColumn<int>(
                name: "productId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Products_productId",
                table: "Items",
                column: "productId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Products_productId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "Items",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_productId",
                table: "Items",
                newName: "IX_Items_ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Items",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Products_ProductId",
                table: "Items",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
