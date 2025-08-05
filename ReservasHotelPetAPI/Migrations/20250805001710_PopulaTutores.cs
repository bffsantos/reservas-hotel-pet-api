using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservasHotelPetAPI.Migrations
{
    /// <inheritdoc />
    public partial class PopulaTutores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO TUTORES(Nome, Idade, Sexo, DataNascimento, Endereco, Telefone, Email, UsuarioId) VALUES('João Silva', 25, 'M', '2000-02-02', 'Rua Mercúrio 1565', '47 9999-8899', 'joao.silva@email.com', 2)");
            mb.Sql("INSERT INTO TUTORES(Nome, Idade, Sexo, DataNascimento, Endereco, Telefone, Email, UsuarioId) VALUES('Márcia Mello', 45, 'F', '1980-02-02', 'Rua Saturno 10', '47 9877-6544', 'marcia.mello@email.com', 3)");
            mb.Sql("INSERT INTO TUTORES(Nome, Idade, Sexo, DataNascimento, Endereco, Telefone, Email, UsuarioId) VALUES('Elon Antunes', 50, 'M', '1975-02-02', 'Rua Júpiter 444', '47 9898-7474', 'elon.antunes@email.com', 4)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM TUTORES");
        }
    }
}
