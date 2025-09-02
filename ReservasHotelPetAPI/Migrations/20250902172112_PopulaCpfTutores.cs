using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservasHotelPetAPI.Migrations
{
    /// <inheritdoc />
    public partial class PopulaCpfTutores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("UPDATE TUTORES SET CPF = '123.456.789-10' WHERE ID = 4");
            mb.Sql("UPDATE TUTORES SET CPF = '109.876.543-21' WHERE ID = 5");
            mb.Sql("UPDATE TUTORES SET CPF = '321.654.987-01' WHERE ID = 6");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("UPDATE TUTORES SET CPF = '' WHERE ID = 4");
            mb.Sql("UPDATE TUTORES SET CPF = '' WHERE ID = 5");
            mb.Sql("UPDATE TUTORES SET CPF = '' WHERE ID = 6");
        }
    }
}
