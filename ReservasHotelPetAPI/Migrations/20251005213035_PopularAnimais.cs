using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservasHotelPetAPI.Migrations
{
    /// <inheritdoc />
    public partial class PopularAnimais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO ANIMAIS(Nome, Idade, Sexo, Tipo, Raca, TutorId) VALUES('Toby', 2, 'M', 'Cachorro', 'Beagle', 1)");
            mb.Sql("INSERT INTO ANIMAIS(Nome, Idade, Sexo, Tipo, Raca, TutorId) VALUES('Charlotte', 4, 'F', 'Cachorro', 'Golden Retrivier', 2)");
            mb.Sql("INSERT INTO ANIMAIS(Nome, Idade, Sexo, Tipo, Raca, TutorId) VALUES('Mel', 2, 'F', 'Gato', 'Whitehair', 3)");
            mb.Sql("INSERT INTO ANIMAIS(Nome, Idade, Sexo, Tipo, Raca, TutorId) VALUES('Rex', 1, 'M', 'Cachorro', 'Pastor Alemão', 1)");
            mb.Sql("INSERT INTO ANIMAIS(Nome, Idade, Sexo, Tipo, Raca, TutorId) VALUES('Jimmy', 6, 'M', 'Papagaio', 'Papagaio-Verdadeiro', 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM ANIMAIS");
        }
    }
}
