using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using ReservasHotelPetAPI.Controllers;
using ReservasHotelPetAPI.DTOs;
using ReservasHotelPetAPITests.UnitTests;

namespace ApiCatalogoxUnitTests.UnitTests;

public class PutAnimaisUnitTests : IClassFixture<AnimaisUnitTestController>
{
    private readonly AnimaisController _controller;

    public PutAnimaisUnitTests(AnimaisUnitTestController controller)
    {
        _controller = new AnimaisController(controller.repository, controller.mapper);
    }

    //testes de unidade para PUT
    [Fact]
    public async Task PutProduto_Return_OkResult()
    {
        //Arrange  
        var prodId = 3;

        var updatedProdutoDto = new AnimalDTO
        {
            Id = prodId,
            Nome = "Novo Animal",
            Idade = 2,
            Raca = "Raca do animal",
            Sexo = 'M',
            Tipo = "Gato",
            TutorId = 1
        };

        // Act
        var result = await _controller.Put(prodId, updatedProdutoDto) as ActionResult<AnimalDTO>;

        // Assert  
        result.Should().NotBeNull(); // Verifica se o resultado não é nulo
        result.Result.Should().BeOfType<OkObjectResult>(); // Verifica se o resultado é OkObjectResult
    }

    [Fact]
    public async Task PutProduto_Return_BadRequest()
    {
        //Arrange
        var prodId = 1000;

        var meuProduto = new AnimalDTO
        {
            Id = 3,
            Nome = "Novo Animal",
            Idade = 2,
            Raca = "Raca do animal",
            Sexo = 'M',
            Tipo = "Gato",
            TutorId = 1
        };

        //Act              
        var data = await _controller.Put(prodId, meuProduto);

        // Assert  
        data.Result.Should().BeOfType<BadRequestResult>().Which.StatusCode.Should().Be(400);

    }
}
