using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PackageTrackingApp.Core.Migrations
{
    public partial class addedDeliveredAtpropforpackage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveredAt",
                table: "Packages",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveredAt",
                table: "Packages");
        }
    }
}
