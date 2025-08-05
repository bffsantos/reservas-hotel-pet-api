using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservasHotelPetAPI.Migrations
{
    /// <inheritdoc />
    public partial class AjustarTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Tutores_TutorId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_TutorId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "TutorId",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Tutores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tutores_UsuarioId",
                table: "Tutores",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tutores_Usuarios_UsuarioId",
                table: "Tutores",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tutores_Usuarios_UsuarioId",
                table: "Tutores");

            migrationBuilder.DropIndex(
                name: "IX_Tutores_UsuarioId",
                table: "Tutores");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Tutores");

            migrationBuilder.AddColumn<int>(
                name: "TutorId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TutorId",
                table: "Usuarios",
                column: "TutorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Tutores_TutorId",
                table: "Usuarios",
                column: "TutorId",
                principalTable: "Tutores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
