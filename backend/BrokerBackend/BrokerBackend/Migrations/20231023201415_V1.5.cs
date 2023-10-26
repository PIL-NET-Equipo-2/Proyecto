using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrokerBackend.Migrations
{
    /// <inheritdoc />
    public partial class V15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Rol_IdRol",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_IdRol",
                table: "Persons");

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
                name: "RolModelIdRol",
                table: "Persons");

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
    }
}
