using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSupplierModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactInfo",
                table: "Suppliers",
                newName: "ContactInfo_PhoneNumber");

            migrationBuilder.AddColumn<string>(
                name: "ContactInfo_Address",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactInfo_Email",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierId",
                table: "Products",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Suppliers_SupplierId",
                table: "Products",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Suppliers_SupplierId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SupplierId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ContactInfo_Address",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "ContactInfo_Email",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ContactInfo_PhoneNumber",
                table: "Suppliers",
                newName: "ContactInfo");
        }
    }
}
