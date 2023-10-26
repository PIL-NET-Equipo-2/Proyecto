using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrokerBackend.Migrations
{
    /// <inheritdoc />
    public partial class V12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonModelRolModel");

            migrationBuilder.AddColumn<int>(
                name: "IdRol",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RolModelIdRol",
                table: "Persons",
                type: "int",
                nullable: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Rol_RolModelIdRol",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_RolModelIdRol",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "IdRol",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "RolModelIdRol",
                table: "Persons");

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

            migrationBuilder.CreateIndex(
                name: "IX_PersonModelRolModel_RolIdRol",
                table: "PersonModelRolModel",
                column: "RolIdRol");
        }
    }
}
