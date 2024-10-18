using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_02.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class updaterequestsv01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Townships_ProvinceId",
                table: "Customers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_TownshipId",
                table: "Customers",
                column: "TownshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Townships_TownshipId",
                table: "Customers",
                column: "TownshipId",
                principalTable: "Townships",
                principalColumn: "TownshipId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Townships_TownshipId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_TownshipId",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Townships_ProvinceId",
                table: "Customers",
                column: "ProvinceId",
                principalTable: "Townships",
                principalColumn: "TownshipId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
