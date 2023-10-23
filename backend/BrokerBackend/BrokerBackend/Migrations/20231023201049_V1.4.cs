using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrokerBackend.Migrations
{
    /// <inheritdoc />
    public partial class V14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Rol_RolModelIdRol",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Stock_IdStock",
                table: "Purchases");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_IdStock",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Persons_RolModelIdRol",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "IdStock",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "RolModelIdRol",
                table: "Persons");

            migrationBuilder.AddColumn<string>(
                name: "Symbol",
                table: "Purchases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_IdRol",
                table: "Persons",
                column: "IdRol");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Rol_IdRol",
                table: "Persons",
                column: "IdRol",
                principalTable: "Rol",
                principalColumn: "IdRol",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Rol_IdRol",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_IdRol",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Symbol",
                table: "Purchases");

            migrationBuilder.AddColumn<int>(
                name: "IdStock",
                table: "Purchases",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RolModelIdRol",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    IdStock = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActiveDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Company = table.Column<string>(type: "varchar(15)", nullable: false),
                    InactiveDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Logo = table.Column<string>(type: "varchar(50)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    Symbol = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.IdStock);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_IdStock",
                table: "Purchases",
                column: "IdStock");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_RolModelIdRol",
                table: "Persons",
                column: "RolModelIdRol");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Rol_RolModelIdRol",
                table: "Persons",
                column: "RolModelIdRol",
                principalTable: "Rol",
                principalColumn: "IdRol");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Stock_IdStock",
                table: "Purchases",
                column: "IdStock",
                principalTable: "Stock",
                principalColumn: "IdStock");
        }
    }
}
