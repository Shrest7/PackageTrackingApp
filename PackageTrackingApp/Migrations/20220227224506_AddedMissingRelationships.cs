using Microsoft.EntityFrameworkCore.Migrations;

namespace PackageTrackingApp.Core.Migrations
{
    public partial class AddedMissingRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Packages_CourierGuid",
                table: "Packages",
                column: "CourierGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_CustomerGuid",
                table: "Packages",
                column: "CustomerGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_SellerGuid",
                table: "Packages",
                column: "SellerGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Couriers_CourierGuid",
                table: "Packages",
                column: "CourierGuid",
                principalTable: "Couriers",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Users_CustomerGuid",
                table: "Packages",
                column: "CustomerGuid",
                principalTable: "Users",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Users_SellerGuid",
                table: "Packages",
                column: "SellerGuid",
                principalTable: "Users",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Couriers_CourierGuid",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Users_CustomerGuid",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Users_SellerGuid",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_CourierGuid",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_CustomerGuid",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_SellerGuid",
                table: "Packages");
        }
    }
}
