using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservasHotelPetAPI.Migrations
{
    /// <inheritdoc />
    public partial class PopulaAnimais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Animais(Nome,Idade,Sexo,Tipo,Raca,TutorId) Values('Toby',1,'M','Cachorro','Beagle',1)");
            mb.Sql("Insert into Animais(Nome,Idade,Sexo,Tipo,Raca,TutorId) Values('Eva',2,'F','Cachorro','Poodle',2)");
            mb.Sql("Insert into Animais(Nome,Idade,Sexo,Tipo,Raca,TutorId) Values('Rex',4,'M','Cachorro','Pastor Alemão',3)");
            mb.Sql("Insert into Animais(Nome,Idade,Sexo,Tipo,Raca,TutorId) Values('Bessie',1,'F','Cachorro','Fila Brasileiro',1)");
            mb.Sql("Insert into Animais(Nome,Idade,Sexo,Tipo,Raca,TutorId) Values('Mel',8,'F','Gato','Beagle','Whitehair',3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Animais");
        }
    }
}
