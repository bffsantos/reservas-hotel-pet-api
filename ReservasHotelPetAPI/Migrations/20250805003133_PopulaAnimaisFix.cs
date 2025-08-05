using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservasHotelPetAPI.Migrations
{
    /// <inheritdoc />
    public partial class PopulaAnimaisFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO ANIMAIS(Nome, Idade, Sexo, Tipo, Raca, TutorId) VALUES('Toby', 2, 'M', 'Cachorro', 'Beagle', 4)");
            mb.Sql("INSERT INTO ANIMAIS(Nome, Idade, Sexo, Tipo, Raca, TutorId) VALUES('Charlotte', 4, 'F', 'Cachorro', 'Golden Retrivier', 5)");
            mb.Sql("INSERT INTO ANIMAIS(Nome, Idade, Sexo, Tipo, Raca, TutorId) VALUES('Mel', 2, 'F', 'Gato', 'Whitehair', 6)");
            mb.Sql("INSERT INTO ANIMAIS(Nome, Idade, Sexo, Tipo, Raca, TutorId) VALUES('Rex', 1, 'M', 'Cachorro', 'Pastor Alemão', 4)");
            mb.Sql("INSERT INTO ANIMAIS(Nome, Idade, Sexo, Tipo, Raca, TutorId) VALUES('Jimmy', 6, 'M', 'Papagaio', 'Papagaio-Verdadeiro', 5)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM ANIMAIS");
        }
    }
}
