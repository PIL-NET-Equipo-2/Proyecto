using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrokerBackend.Migrations
{
    /// <inheritdoc />
    public partial class v10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    IdPerson = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(15)", nullable: false),
                    Lastname = table.Column<string>(type: "varchar(15)", nullable: false),
                    Dni = table.Column<string>(type: "varchar(15)", nullable: false),
                    Gender = table.Column<string>(type: "varchar(15)", nullable: false),
                    Mail = table.Column<string>(type: "varchar(15)", nullable: false),
                    Password = table.Column<string>(type: "varchar(15)", nullable: false),
                    State = table.Column<string>(type: "varchar(15)", nullable: false),
                    City = table.Column<string>(type: "varchar(15)", nullable: false),
                    Adress = table.Column<string>(type: "varchar(15)", nullable: false),
                    AccountMoney = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    ActiveDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InactiveDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.IdPerson);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    IdStock = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(type: "varchar(50)", nullable: false),
                    Company = table.Column<string>(type: "varchar(15)", nullable: false),
                    Logo = table.Column<string>(type: "varchar(50)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    ActiveDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InactiveDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.IdStock);
                });

            migrationBuilder.CreateTable(
                name: "PersonModelRolModel",
                columns: table => new
                {
                    PersonIdPerson = table.Column<int>(type: "int", nullable: false),
                    RolIdRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonModelRolModel", x => new { x.PersonIdPerson, x.RolIdRol });
                    table.ForeignKey(
                        name: "FK_PersonModelRolModel_Persons_PersonIdPerson",
                        column: x => x.PersonIdPerson,
                        principalTable: "Persons",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonModelRolModel_Rol_RolIdRol",
                        column: x => x.RolIdRol,
                        principalTable: "Rol",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    IdPurchase = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    IdPerson = table.Column<int>(type: "int", nullable: true),
                    IdStock = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.IdPurchase);
                    table.ForeignKey(
                        name: "FK_Purchases_Persons_IdPerson",
                        column: x => x.IdPerson,
                        principalTable: "Persons",
                        principalColumn: "IdPerson");
                    table.ForeignKey(
                        name: "FK_Purchases_Stock_IdStock",
                        column: x => x.IdStock,
                        principalTable: "Stock",
                        principalColumn: "IdStock");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonModelRolModel_RolIdRol",
                table: "PersonModelRolModel",
                column: "RolIdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_IdPerson",
                table: "Purchases",
                column: "IdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_IdStock",
                table: "Purchases",
                column: "IdStock");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonModelRolModel");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Stock");
        }
    }
}
