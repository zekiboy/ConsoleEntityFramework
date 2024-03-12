using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace entityFramework.Migrations
{
    /// <inheritdoc />
    public partial class supplierOneToOneGuncelleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Suppliers_UserUserId",
                table: "Suppliers");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_UserUserId",
                table: "Suppliers",
                column: "UserUserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Suppliers_UserUserId",
                table: "Suppliers");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_UserUserId",
                table: "Suppliers",
                column: "UserUserId");
        }
    }
}
