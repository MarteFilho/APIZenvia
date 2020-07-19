using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCatalog_Store_UserId",
                table: "ProductCatalog");

            migrationBuilder.DropIndex(
                name: "IX_ProductCatalog_UserId",
                table: "ProductCatalog");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProductCatalog");

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "ProductCatalog",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCatalog_StoreId",
                table: "ProductCatalog",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCatalog_Store_StoreId",
                table: "ProductCatalog",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCatalog_Store_StoreId",
                table: "ProductCatalog");

            migrationBuilder.DropIndex(
                name: "IX_ProductCatalog_StoreId",
                table: "ProductCatalog");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "ProductCatalog");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ProductCatalog",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCatalog_UserId",
                table: "ProductCatalog",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCatalog_Store_UserId",
                table: "ProductCatalog",
                column: "UserId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
