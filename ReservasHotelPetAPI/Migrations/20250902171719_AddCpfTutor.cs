using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservasHotelPetAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCpfTutor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Tutores",
                type: "varchar(14)",
                maxLength: 14,
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Tutores");
        }
    }
}
