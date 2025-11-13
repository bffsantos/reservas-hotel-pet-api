using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservasHotelPetAPI.Migrations
{
    /// <inheritdoc />
    public partial class PopulaTabelasIniciais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            // Popula tutores
            mb.Sql(@"
                INSERT INTO Tutores (Nome, Idade, Sexo, DataNascimento, Cpf, Endereco, Telefone, Email)
                VALUES 
                ('João Silva', 25, 'M', '2000-02-02', '123.456.789-10', 'Rua Mercúrio 1565', '47 9999-8899', 'joao.silva@email.com'),
                ('Márcia Mello', 45, 'F', '1980-02-02', '109.876.543-21', 'Rua Saturno 10', '47 9877-6544', 'marcia.mello@email.com'),
                ('Elon Antunes', 50, 'M', '1975-02-02', '321.654.987-01', 'Rua Júpiter 444', '47 9898-7474', 'elon.antunes@email.com');
            ");

            // Popula animais
            mb.Sql(@"
                INSERT INTO Animais (Nome, Idade, Sexo, Tipo, Raca, TutorId)
                VALUES 
                ('Toby', 2, 'M', 'Cachorro', 'Beagle', 1),
                ('Charlotte', 4, 'F', 'Cachorro', 'Golden Retrivier', 2),
                ('Mel', 2, 'F', 'Gato', 'Whitehair', 3),
                ('Rex', 1, 'M', 'Cachorro', 'Pastor Alemão', 1),
                ('Jimmy', 6, 'M', 'Papagaio', 'Papagaio-Verdadeiro', 3);
            ");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Animais;");
            mb.Sql("DELETE FROM Tutores;");
        }
    }
}
