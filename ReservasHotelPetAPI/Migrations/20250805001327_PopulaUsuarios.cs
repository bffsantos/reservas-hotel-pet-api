using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservasHotelPetAPI.Migrations
{
    /// <inheritdoc />
    public partial class PopulaUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO USUARIOS(Login, Senha) VALUES('joao', '123')");
            mb.Sql("INSERT INTO USUARIOS(Login, Senha) VALUES('marcia', '456')");
            mb.Sql("INSERT INTO USUARIOS(Login, Senha) VALUES('elon', '789')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM USUARIOS");
        }
    }
}
