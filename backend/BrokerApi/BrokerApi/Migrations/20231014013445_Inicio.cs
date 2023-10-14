using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrokerApi.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acciones",
                columns: table => new
                {
                    IdAccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Simbolo = table.Column<string>(type: "varchar(50)", nullable: false),
                    Empresa = table.Column<string>(type: "varchar(15)", nullable: false),
                    Logo = table.Column<string>(type: "varchar(50)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acciones", x => x.IdAccion);
                });

            migrationBuilder.CreateTable(
                name: "Localidades",
                columns: table => new
                {
                    IdLocalidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(15)", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidades", x => x.IdLocalidad);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(15)", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    IdPersona = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(15)", nullable: false),
                    Apellido = table.Column<string>(type: "varchar(15)", nullable: false),
                    Dni = table.Column<string>(type: "varchar(15)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "date", nullable: false),
                    Usuario = table.Column<string>(type: "varchar(15)", nullable: false),
                    Contrasenia = table.Column<string>(type: "varchar(15)", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdLocalidad = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.IdPersona);
                    table.ForeignKey(
                        name: "FK_Personas_Localidades_IdLocalidad",
                        column: x => x.IdLocalidad,
                        principalTable: "Localidades",
                        principalColumn: "IdLocalidad");
                });

            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    IdCuenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cbu = table.Column<string>(type: "varchar(15)", nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    EstaHabilitada = table.Column<bool>(type: "bit", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdPersona = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.IdCuenta);
                    table.ForeignKey(
                        name: "FK_Cuentas_Personas_IdPersona",
                        column: x => x.IdPersona,
                        principalTable: "Personas",
                        principalColumn: "IdPersona");
                });

            migrationBuilder.CreateTable(
                name: "PersonaModelRolModel",
                columns: table => new
                {
                    PersonasIdPersona = table.Column<int>(type: "int", nullable: false),
                    RolesIdRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaModelRolModel", x => new { x.PersonasIdPersona, x.RolesIdRol });
                    table.ForeignKey(
                        name: "FK_PersonaModelRolModel_Personas_PersonasIdPersona",
                        column: x => x.PersonasIdPersona,
                        principalTable: "Personas",
                        principalColumn: "IdPersona",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonaModelRolModel_Roles_RolesIdRol",
                        column: x => x.RolesIdRol,
                        principalTable: "Roles",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    IdCompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    FechaBaja = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdCuenta = table.Column<int>(type: "int", nullable: true),
                    IdAccion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.IdCompra);
                    table.ForeignKey(
                        name: "FK_Compras_Acciones_IdAccion",
                        column: x => x.IdAccion,
                        principalTable: "Acciones",
                        principalColumn: "IdAccion");
                    table.ForeignKey(
                        name: "FK_Compras_Cuentas_IdCuenta",
                        column: x => x.IdCuenta,
                        principalTable: "Cuentas",
                        principalColumn: "IdCuenta");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compras_IdAccion",
                table: "Compras",
                column: "IdAccion");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_IdCuenta",
                table: "Compras",
                column: "IdCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_IdPersona",
                table: "Cuentas",
                column: "IdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaModelRolModel_RolesIdRol",
                table: "PersonaModelRolModel",
                column: "RolesIdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_IdLocalidad",
                table: "Personas",
                column: "IdLocalidad");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "PersonaModelRolModel");

            migrationBuilder.DropTable(
                name: "Acciones");

            migrationBuilder.DropTable(
                name: "Cuentas");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Localidades");
        }
    }
}
